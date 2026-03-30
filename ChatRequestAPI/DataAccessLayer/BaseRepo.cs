using DataAccessLayer.EF_core;
using DataAccessLayer.Interfaces;
using Domain;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public abstract class BaseRepo<TEntity> : IBaseRepo<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _dbContext;
        string _tableName = "";
        public BaseRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _tableName = GetTableName(typeof(TEntity).Name);
        }
        public static string GetTableName(string tableName)
        {
            string suffix = "Entity";
            if (tableName.EndsWith(suffix))
            {
                return tableName.Substring(0, tableName.Length - suffix.Length);
            }
            return tableName;
        }

        public virtual async Task<bool> Insert(List<TEntity> model)
        {
            if (model == null)
            {
                return false;
            }
            else
            {
                try
                {
                    await _dbContext.Set<TEntity>().AddRangeAsync(model);
                    int rowsAffected = await _dbContext.SaveChangesAsync();
                    return rowsAffected > 0;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
        public virtual async Task<bool> UpdateByID(TEntity model, Guid ID)
        {
            var existingEntity = await _dbContext.Set<TEntity>().FindAsync(ID);
            if (existingEntity == null)
            { return false; }

            foreach (var property in typeof(TEntity).GetProperties())
            {
                var newValue = property.GetValue(model);
                if (newValue != null)
                {
                    property.SetValue(existingEntity, newValue);
                }
            }

            await _dbContext.SaveChangesAsync();
            return true;

        }

        public virtual async Task<bool> DeleteByID(Guid ID)
        {
            var Model = await _dbContext.Set<TEntity>().FindAsync(ID);
            if (Model == null)
            {
                return false; 
            }
            else
            {
                _dbContext.Set<TEntity>().Remove(Model);
                await _dbContext.SaveChangesAsync();
                return true;
            }    
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            var result = await _dbContext.Set<TEntity>().ToListAsync();
            return result;
        }

        public async Task<TEntity> GetByID(Guid ID)
        {
            var result = await _dbContext.Set<TEntity>().FindAsync(ID);
            return Activator.CreateInstance<TEntity>();
        }
        public async Task<List<TEntity>> GetByCondition(List<FilterCondition> filters)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (filters != null && filters.Any())
            {
                ParameterExpression param = Expression.Parameter(typeof(TEntity), "x");
                Expression finalExpression = null;

                foreach (var filter in filters)
                {
                    var property = Expression.Property(param, filter.Field);
                    var constant = Expression.Constant(Convert.ChangeType(filter.Value, property.Type));

                    Expression comparison = filter.Operator switch
                    {
                        "=" => Expression.Equal(property, constant),
                        ">" => Expression.GreaterThan(property, constant),
                        "<" => Expression.LessThan(property, constant),
                        ">=" => Expression.GreaterThanOrEqual(property, constant),
                        "<=" => Expression.LessThanOrEqual(property, constant),
                        "Contains" => Expression.Call(property, "Contains", null, constant),
                        _ => throw new NotSupportedException($"Operator {filter.Operator} not supported")
                    };

                    finalExpression = finalExpression == null
                        ? comparison
                        : Expression.AndAlso(finalExpression, comparison);
                }

                var lambda = Expression.Lambda<Func<TEntity, bool>>(finalExpression, param);
                query = query.Where(lambda);
            }

            return await query.ToListAsync();
        }
    }
}

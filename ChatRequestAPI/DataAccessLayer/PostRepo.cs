using DataAccessLayer.EF_core;
using DataAccessLayer.Interfaces;
using Domain;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PostRepo : BaseRepo<PostsEntity>, IPostRepo
    {
        public PostRepo(AppDbContext dbcontext) : base(dbcontext)
        {

        }
        public async Task InsertPost(PostsEntity payload)
        {
            var result = _dbContext.posts.Add(payload);
        }


    }
}

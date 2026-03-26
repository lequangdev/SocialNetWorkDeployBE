using DataAccessLayer.EF_core;
using DataAccessLayer.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CommentRepo : BaseRepo<Post_commentsEntity>, ICommentRepo
    {
    
        public CommentRepo(AppDbContext context) : base(context)
        {

        }
        public Task<List<Post_commentsEntity>> GetAllCommentByPost_id(Guid post_id)
        {
            return _dbContext.post_comments.Where(x => x.posts_id == post_id).ToListAsync();
        }
    }
}

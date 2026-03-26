using DataAccessLayer.EF_core;
using DataAccessLayer.Interfaces;
using Domain;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class CommentService : BaseService<Post_commentsEntity>, ICommentService
    {
        private readonly ICommentRepo _commentRepo;
        public CommentService(ICommentRepo commentRepo, AppDbContext dbContext) : base(commentRepo, dbContext)
        {
            _commentRepo = commentRepo;
        }

        public Task<List<Post_commentsEntity>> GetAllCommentByPost_id(Guid post_id)
        {
            return _commentRepo.GetAllCommentByPost_id(post_id);
        }
    }
}

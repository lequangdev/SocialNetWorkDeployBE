using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICommentRepo : IBaseRepo<Post_commentsEntity>
    {
        Task<List<Post_commentsEntity>> GetAllCommentByPost_id(Guid post_id);
    }
}

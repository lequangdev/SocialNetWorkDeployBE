using Domain;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface ICommentService : IBaseService<Post_commentsEntity>
    {
        Task<List<Post_commentsEntity>> GetAllCommentByPost_id(Guid post_id);
    }
}

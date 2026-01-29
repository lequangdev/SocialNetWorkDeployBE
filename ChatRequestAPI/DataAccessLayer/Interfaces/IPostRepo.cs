using Domain;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IPostRepo : IBaseRepo<PostsEntity>
    {
        public Task InsertPost(PostsEntity payload);
        public Task<List<PostsEntity>> GetPostsByUserId(Guid user_id);
        public Task<List<PostDTO>> GetAllPostsDetail();
    }
}

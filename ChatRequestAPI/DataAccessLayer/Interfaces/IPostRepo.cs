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
    }
}

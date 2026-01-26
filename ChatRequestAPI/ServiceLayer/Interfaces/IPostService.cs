using Domain;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IPostService : IBaseService<PostsEntity>
    {
        public Task<bool> InsertPost(PostDTO payload);

    }
}

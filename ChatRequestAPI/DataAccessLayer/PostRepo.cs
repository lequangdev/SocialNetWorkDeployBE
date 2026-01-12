using DataAccessLayer.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PostRepo : BaseRepo<PostsEntity>, IPostRepo
    {
        public PostRepo(EF_core.AppDbContext context) : base(context)
        {

        }
    }
}

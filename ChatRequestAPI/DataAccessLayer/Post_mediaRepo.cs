using DataAccessLayer.EF_core;
using DataAccessLayer.Interfaces;
using Domain;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Post_mediaRepo : BaseRepo<Post_mediaEntity>, IPost_mediaRepo
    {
        public Post_mediaRepo(AppDbContext context) : base(context)
        {

        }
        public async Task insertListMedia(List<Post_mediaEntity> medias)
        {
           await _dbContext.post_media.AddRangeAsync(medias);
        }

    }
}

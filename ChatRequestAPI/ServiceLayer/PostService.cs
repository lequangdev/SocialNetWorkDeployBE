using DataAccessLayer;
using DataAccessLayer.EF_core;
using DataAccessLayer.Interfaces;
using Domain;
using DTO;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Enums.PostEnum;

namespace ServiceLayer
{
    public class PostService : BaseService<PostsEntity>, IPostService
    {
        private readonly IPostRepo _postRepo;
        private readonly IPost_mediaRepo _post_MediaRepo;
        public PostService( IPostRepo postRepo, IPost_mediaRepo post_MediaRepo, AppDbContext dbContext) : base(postRepo, dbContext) 
        {
            _postRepo = postRepo;
            _post_MediaRepo = post_MediaRepo;
        }

        public async Task<bool> InsertPost(PostDTO payload)
        {
            try
            {
                var post_id = Guid.NewGuid();
                PostsEntity post = new PostsEntity
                {
                    posts_id = post_id,
                    user_id = payload.user_id,
                    content = payload.content,
                    status = 1,
                    media_count = payload.mediaDTOs.Count,
                    privacy = 1,
                };
                    await _postRepo.InsertPost(post);
   
                if(payload.media_count > 0)
                {
                    List<Post_mediaEntity> postMediaList = new List<Post_mediaEntity>();
                    foreach (var media in payload.mediaDTOs)
                    {
                        Post_mediaEntity post_Media = new Post_mediaEntity
                        {
                            post_media_id = Guid.NewGuid(),
                            posts_id = post_id,
                            media_url = media.media_url,
                            media_type = media.media_type
                        };
                        postMediaList.Add(post_Media);
                    }
                    await _post_MediaRepo.insertListMedia(postMediaList);
                }
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw; 
            }
        }


    }
}

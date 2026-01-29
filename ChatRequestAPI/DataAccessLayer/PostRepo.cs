using DataAccessLayer.EF_core;
using DataAccessLayer.Interfaces;
using Domain;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PostRepo : BaseRepo<PostsEntity>, IPostRepo
    {
        public PostRepo(AppDbContext dbcontext) : base(dbcontext)
        {

        }
        public async Task InsertPost(PostsEntity payload)
        {
            var result = _dbContext.posts.Add(payload);
        }
        public async Task<List<PostsEntity>> GetPostsByUserId(Guid user_id)
        {
            var result = await _dbContext.posts.Where(p => p.user_id == user_id).ToListAsync();
            return result;
        }
        public async Task<List<PostDTO>> GetAllPostsDetail()
        {
            var posts = await _dbContext.posts
            .Select(p => new PostDTO
            {
                posts_id = p.posts_id,
                user_id = p.user_id,
                content = p.content,
                privacy = p.privacy,
                status = p.status,
                media_count = p.media_count,
                like_count = p.like_count,
                comment_count = p.comment_count,
                created_date = p.created_date,
                modified_date = p.modified_date,
                user = new UserPublicDTO
                {
                    user_id = p.user.user_id,
                    user_fullName = p.user.user_fullName,
                    user_avatar = p.user.user_avatar
                },
                mediaDTOs = p.medias.Select(m => new Post_mediaDTO
                {
                    post_media_id = m.post_media_id,
                    media_url = m.media_url,
                    media_type = m.media_type
                }).ToList(),
                userLikes = p.likes.Select(l => new Post_likesDTO
                {
                    post_likes_id = l.post_likes_id,
                    user_id = l.user_id,
                }).ToList(),
                userComments = p.comments.Select(c => new PostCommentsDTO
                {
                    post_comments_id = c.post_comments_id,
                    user_id = c.user_id,
                    content = c.content
                }).ToList(),
            })
            .ToListAsync();

            return posts;
        }
    }
}

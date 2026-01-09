using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EF_core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UserEntity> user { get; set; }
        public DbSet<MessageEntity> message { get; set; }
        public DbSet<Room_chatEntity> room_chat { get; set; }
        public DbSet<Room_userEntity> room_user { get; set; }
        public DbSet<FriendshipEntity> friendship { get; set; }
        public DbSet<PostsEntity> posts { get; set; }
        public DbSet<Post_mediaEntity> post_media { get; set; }
        public DbSet<Post_likesEntity> post_likes { get; set; }
        public DbSet<Post_commentsEntity> post_comments { get; set; }
        public DbSet<Comments_mediaEntity> comments_media { get; set; }
    }
}

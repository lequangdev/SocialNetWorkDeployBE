using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Enums.PostEnum;

namespace Domain
{
    public class PostsEntity : AuditableEntity
    {
        [Key]
        public Guid? posts_id { get; set; }
        public Guid? user_id { get; set; }
        public string? content { get; set; }
        public PostPrivacy privacy { get; set; } 
        public PostStatus status { get; set; } 
        public int media_count { get; set; } = 0;
        public int? like_count { get; set; } = 0;
        public int? comment_count { get; set; } = 0;

        [ForeignKey("user_id")]
        public UserEntity user { get; set; }
        public ICollection<Post_mediaEntity> medias { get; set; }
        = new List<Post_mediaEntity>();
        public ICollection<Post_likesEntity> likes { get; set; }
        = new List<Post_likesEntity>();
        public ICollection<Post_commentsEntity> comments { get; set; }
        = new List<Post_commentsEntity>();
    }
}

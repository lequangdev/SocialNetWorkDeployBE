
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Enums.PostEnum;

namespace Domain
{
    public class Post_commentsEntity : AuditableEntity
    {
        [Key]
        public Guid post_comments_id { get; set; } 
        public Guid posts_id { get; set; }
        public Guid user_id { get; set; } 
        public string content { get; set; } 
        public PostStatus status { get; set; } = PostStatus.Active;
        [ForeignKey("posts_id")]
        public PostsEntity posts { get; set; }
        [ForeignKey("user_id")]
        public UserEntity user { get; set; }

    }
}

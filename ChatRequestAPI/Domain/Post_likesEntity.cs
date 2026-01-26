using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Post_likesEntity : AuditableEntity
    {
        [Key]
        public Guid post_likes_id { get; set; }
        public Guid posts_id { get; set; }
        public Guid user_id { get; set; } 
        public string? likes_type { get; set; }

        [ForeignKey("posts_id")]
        public PostsEntity posts { get; set; }
        [ForeignKey("user_id")]
        public UserEntity user { get; set; }
    }
}

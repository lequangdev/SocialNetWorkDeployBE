using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enum;

namespace Domain
{
    public class Post_commentsEntity : AuditableEntity
    {
        public Guid post_comments_id { get; set; } 
        public Guid posts_id { get; set; }
        public Guid user_id { get; set; } 
        public string content { get; set; } 
        public EntityStatus status { get; set; } = EntityStatus.Active;
        [ForeignKey("posts_id")]
        public PostsEntity posts { get; set; }
        [ForeignKey("user_id")]
        public UserEntity user { get; set; }

    }
}

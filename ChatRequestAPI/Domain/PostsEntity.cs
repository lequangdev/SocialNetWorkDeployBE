using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enum;

namespace Domain
{
    public class PostsEntity : AuditableEntity
    {
        public Guid posts_id { get; set; }
        public Guid user_id { get; set; }
        public string? content { get; set; }

        public PostPrivacy privacy { get; set; } = PostPrivacy.Friends;
        public EntityStatus status { get; set; } = EntityStatus.Active;

        public int like_count { get; set; }
        public int comment_count { get; set; }

        [ForeignKey("user_id")]
        public UserEntity user { get; set; }
    }
}

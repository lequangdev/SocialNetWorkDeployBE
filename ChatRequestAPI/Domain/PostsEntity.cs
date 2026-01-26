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
        public int privacy { get; set; } 
        public int status { get; set; } 
        public int media_count { get; set; } = 0;
        public int? like_count { get; set; } = 0;
        public int? comment_count { get; set; } = 0;

        [ForeignKey("user_id")]
        public UserEntity user { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Enums.PostEnum;

namespace DTO
{
    public class PostCommentsDTO
    {
        public Guid post_comments_id { get; set; }
        public Guid user_id { get; set; }
        public string content { get; set; }
        public PostStatus status { get; set; } = PostStatus.Active;
        public DateTime? created_date { get; set; }
        public string user_fullName { get; set; }
        public string user_avatar { get;set; }
    }
}

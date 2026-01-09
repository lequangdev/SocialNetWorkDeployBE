using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Post_mediaEntity : AuditableEntity
    {
        public Guid post_media_id { get; set; }

        public Guid posts_id { get; set; }
        public string media_url { get; set; } = null!;
        public string? media_type { get; set; }
        [ForeignKey("posts_id")]
        public PostsEntity posts { get; set; }
    }
}

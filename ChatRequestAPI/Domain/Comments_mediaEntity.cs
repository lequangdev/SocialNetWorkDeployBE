using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enum;

namespace Domain
{
    public class Comments_mediaEntity : AuditableEntity
    {
        public Guid comments_media_id { get; set; } 
        public Guid post_comments_id { get; set; } 
        public string? comments_media_type { get; set; }
        public EntityStatus status { get; set; } = EntityStatus.Active;

        [ForeignKey("post_comments_id")]
        public Post_commentsEntity post_comments { get; set; }

    }

}

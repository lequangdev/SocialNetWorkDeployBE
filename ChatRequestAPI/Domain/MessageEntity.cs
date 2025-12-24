using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MessageEntity : AuditableEntity
    {
        [Key]
        public Guid? message_id { get; set; }
        public string? message_content { get; set; }
        public string? message_type { get; set; }
        public Guid? room_id { get; set; }
        public Guid? user_id { get; set; }
        public int? message_status { get; set; }
    }
}

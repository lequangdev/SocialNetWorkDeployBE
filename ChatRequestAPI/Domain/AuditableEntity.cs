using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AuditableEntity
    {
        public string? created_by { get; set; }
        public DateTime? created_date { get; set; } = DateTime.Now;
        public string? modified_by { get; set; }
        public DateTime? modified_date { get; set; } = DateTime.Now;
    }
}

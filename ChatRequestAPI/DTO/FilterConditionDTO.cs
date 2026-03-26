using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FilterCondition
    {
        public string Field { get; set; }          // tên cột
        public object Value { get; set; }          // giá trị so sánh
        public string Operator { get; set; }       // =, >, <, Contains, ...
    }
}

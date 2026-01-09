using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Enum
    {
        public enum PostPrivacy : byte
        {
            Private = 0,
            Friends = 1,
            Public = 2
        }

        public enum EntityStatus : byte
        {
            Inactive = 0,
            Active = 1
        }
    }
}

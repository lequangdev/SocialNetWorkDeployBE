using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    public class PostEnum
    {
        public enum PostPrivacy : byte
        {
            Private = 0,
            Friends = 1,
            Public = 2
        }

        public enum PostStatus : byte
        {
            Inactive = 0,
            Active = 1
        }
    }
}

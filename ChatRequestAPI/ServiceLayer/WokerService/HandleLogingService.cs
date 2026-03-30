using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.WokerService
{
    public class HandleLogingService
    {

        private readonly ILoggingService _loggingService;
        public HandleLogingService()
        {
        }
        public void HandleLoging()
        {
            Console.WriteLine("HandleLogingService is running...");
        }
    }
}


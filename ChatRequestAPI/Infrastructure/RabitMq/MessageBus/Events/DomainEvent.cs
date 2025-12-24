using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RabitMq.MessageBus.Events
{
    public static class DomainEvent
    {
        public record SmsNotificationEvent : INotificationEvent
        {
            public string name { get; set; }
            public string description { get; set; }
            public string type { get; set; }
            public Guid transactionId { get; set; }
            public Guid MessageId { get ; set ; }
            public DateTimeOffset timeStamp { get ; set ;}
        }

        public record EmailNotificationEvent : INotificationEvent
        {
            public string name { get; set;}
            public string description { get; set;}
            public string type { get; set; }
            public Guid transactionId { get; set;}
            public Guid MessageId { get; set; }
            public DateTimeOffset timeStamp { get; set; }
        }
    }
}

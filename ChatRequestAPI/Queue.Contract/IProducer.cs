using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.RabitMq.MessageBus.Events.DomainEvent;

namespace Queue.Contract
{
    public interface IProducer
    {
        Task PublishSms(SmsNotificationEvent paramSms);
    }
}

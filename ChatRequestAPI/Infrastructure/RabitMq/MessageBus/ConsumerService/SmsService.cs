using Infrastructure.RabitMq.MessageBus.Consumers;
using Infrastructure.RabitMq.MessageBus.ConsumerService.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.RabitMq.MessageBus.Events.DomainEvent;

namespace Infrastructure.RabitMq.MessageBus.ConsumerService
{
    public class SmsService : Consumer<SmsNotificationEvent>, ISmsService
    {
        //public SmsService(ISender sender) : base(sender)
        //{

        //}
    }
}

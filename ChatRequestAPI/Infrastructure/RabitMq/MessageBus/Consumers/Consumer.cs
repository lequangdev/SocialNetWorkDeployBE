using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.RabitMq.MessageBus.ConsumerService.Interface;
using Infrastructure.RabitMq.MessageBus.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Infrastructure.RabitMq.MessageBus.Consumers
{
    public abstract class Consumer<TMessage> : IConsumer<TMessage>
        where TMessage : class, INotificationEvent
    {
        //private readonly ISender _sender;

        //protected Consumer(ISender sender)
        //{
        //    _sender = sender;
        //}
        public async Task Consume(ConsumeContext<TMessage> context)
        {
            //await _sender.Send(context.Message);
        }
    }
}

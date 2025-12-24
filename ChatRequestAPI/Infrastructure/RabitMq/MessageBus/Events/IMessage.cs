using MassTransit;
using MediatR;


namespace Infrastructure.RabitMq.MessageBus.Events
{
    [ExcludeFromTopology]
    public interface IMessage : IRequest
    {
        public Guid MessageId { get; set; }
        public DateTimeOffset timeStamp { get; set; }
    }
}

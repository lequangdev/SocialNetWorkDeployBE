using MassTransit;

namespace Infrastructure.RabitMq.MessageBus.Events
{
    public interface INotificationEvent : IMessage
    {
        public string name { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public Guid transactionId { get; set; }
    }
}
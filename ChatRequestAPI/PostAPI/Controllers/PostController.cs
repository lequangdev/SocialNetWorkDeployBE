using Infrastructure.RabitMq.MessageBus.Events;
using Infrastructure.RabitMq.MessageBus.Events.Constants;
using Infrastructure.RabitMq.MessageBus.Producers;
using Microsoft.AspNetCore.Mvc;

namespace PostAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IProducer _producer;

        public PostController(IProducer producer)
        {
            _producer = producer;
        }
        [HttpPost(Name = "publish-sms-notification")]
        public async Task<ActionResult> publishSmsNotificationEvent()
        {
            return Accepted();
        }

    }
}

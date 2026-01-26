using Domain;
using DTO;
using Infrastructure.RabitMq.MessageBus.Events;
using Infrastructure.RabitMq.MessageBus.Events.Constants;
using Infrastructure.RabitMq.MessageBus.Producers;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.Interfaces;

namespace PostAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IProducer _producer;
        private readonly IPostService _postService;

        public PostController(IProducer producer, IPostService postService)
        {
            _postService = postService;
            _producer = producer;
        }
        [HttpPost("InsertPost")]
        public async Task<bool> InsertPost(PostDTO payload)
        {
            try
            {
                return await _postService.InsertPost(payload);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("GetAll")]
        public async Task<List<PostsEntity>> GetAll()
        {
            try
            {
                return await _postService.GetAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

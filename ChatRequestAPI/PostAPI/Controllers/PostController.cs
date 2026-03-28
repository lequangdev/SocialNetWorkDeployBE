using Domain;
using DTO;
using Infrastructure.RabitMq.MessageBus.Events;
using Infrastructure.RabitMq.MessageBus.Events.Constants;
using Infrastructure.RabitMq.MessageBus.Producers;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ICommentService _commentService;

        public PostController(IProducer producer, IPostService postService, ICommentService commentService)
        {
            _postService = postService;
            _producer = producer;
            _commentService = commentService;

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

        [HttpGet("GetAllPostsDetailPubllic")]
        public async Task<List<PostDTO>> GetAllPosGetAllPostsDetailPubllictsDetail()
        {
            try
            {
                return await _postService.GetAllPostsDetailPubllic();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetAllCommentByPost_id")]
        public async Task<ActionResult<List<Post_commentsEntity>>> GetAllCommentByPost_id([FromHeader] Guid room_id)
        {
            try
            {
                var result = await _commentService.GetAllCommentByPost_id(room_id);
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

    }
}

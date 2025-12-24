using Microsoft.AspNetCore.Mvc;
using MassTransit;
using Microsoft.Extensions.Logging;
using Infrastructure.RabitMq.MessageBus.ConsumerService.Interface;
using Infrastructure.RabitMq.MessageBus.ConsumerService;
using Infrastructure.Serilog;
using Infrastructure.Jwt;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.Redis;
using HostBase.Controller;
using ServiceLayer.Interfaces;
using Domain;
using DTO;
using System.Collections.Generic;
using Infrastructure.RabitMq.MessageBus.Producers;
using Infrastructure.RabitMq.MessageBus.Events;
using Infrastructure.RabitMq.MessageBus.Events.Constants;
using Infrastructure.RabitMq.MessageBus.Consumers;

namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthUserController : BaseApi<UserEntity>
    {
        private readonly IProducer _producer;
        private readonly ILoggingService _loggingService;
        private readonly ISmsService _smsService;
        private readonly IJwtService _jwtService;
        private readonly IResponseCacheService _responseCacheService;
        private readonly IUserService _UserService;

        public AuthUserController 
        (
            IProducer producer,
            ILoggingService loggingService,
            IJwtService jwtService,
            IResponseCacheService responseCacheService,
            IUserService UserService,
            ISmsService smsService
        ) : base(UserService)
        {
            _producer = producer;
            _loggingService = loggingService;
            _jwtService = jwtService;
            _responseCacheService = responseCacheService;
            _UserService = UserService;
            _smsService = smsService;
        }

        [HttpPost("InsertUser")]
        public async Task<IActionResult> InsertUser([FromBody] UserEntity user)
        {
            try
            {
                bool result = await _UserService.InsertUser(user);
                if (result)
                {
                    return Ok(new { message = "Đăng ký tài khoản thành công" });
                }
                else
                {
                    return StatusCode(500, new { message = "Failed to insert user" });
                }
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
                
            }

        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDTO request)
        {
            try
            {
                UserEntity result = await _UserService.LoginUser(request.user_account!, request.user_password!);
                if (result != null)
                {
                    
                    var token = _jwtService.GenerateUserToken(result.user_id);
                    var response = new
                    {
                        Token = token,
                        User = result 
                    };
                    return Ok(response);
                }
                else
                {
                    return StatusCode(500, new { message = "Tài khoản hoặc mất khẩu không chính xác" });
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = "Internal server error", error = ex.Message });

            }

        }

        [HttpGet("GetUserByFullname")]
        public async Task<IActionResult> GetUserByFullname([FromHeader] string payload)
        {
            try
            {
                var result = await _UserService.GetUserByFullname(payload);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });

            }

        }
        [HttpGet("test")]
        public async Task<bool> test([FromHeader] string payload)
        {
            try
            {
                await _producer.PublishSms(new DomainEvent.SmsNotificationEvent()
                {
                   MessageId = Guid.NewGuid(),
                     name = "Test SMS",
                        description = "This is a test SMS notification",
                        type = NotificationType.sms,
                        transactionId = Guid.NewGuid(),
                        timeStamp = DateTimeOffset.Now
                });
               
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }







    }
}

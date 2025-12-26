using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using SignalRChat;
using ChatRequestAPI;
using Infrastructure.DependencyInjection.Extentions;
using Infrastructure.Jwt;
using Infrastructure.RabitMq.MessageBus.ConsumerService.Interface;
using Infrastructure.RabitMq.MessageBus.ConsumerService;
using Infrastructure.Serilog;
using Infrastructure.Redis;
using DataAccessLayer.EF_core;
using ServiceLayer.Interfaces;
using ServiceLayer;
using ChatAPI;
using DataAccessLayer.Interfaces;
using DataAccessLayer;
using Infrastructure.RabitMq.MessageBus.Producers;
var builder = WebApplication.CreateBuilder(args);



// Configure CORS ( cho phép gửi request )
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy
            .SetIsOriginAllowed(origin =>
            {
                var host = new Uri(origin).Host;
                return host == "localhost"
                    || host == "social-net-work-deploy-dl89.vercel.app";
            })
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});


// DI services
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IMessageRepo, MessageRepo>();
builder.Services.AddScoped<IRoom_UserService, Room_UserService>();
builder.Services.AddScoped<IRoom_chatRepo, Room_chatRepo>();
builder.Services.AddScoped<IRoom_userRepo, Room_userRepo>();
builder.Services.AddScoped<IFriendshipService, FriendshipService>();
builder.Services.AddScoped<IFriendshipRepo, FriendshipRepo>();


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSignalR(); // Add SignalR services

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Config masstransit rabitmq
builder.Services.AddConfigureMasstransitRabtiMQ(builder.Configuration);
// Producer injection
builder.Services.AddScoped<IProducer, Producer>();
// Consumer injection
builder.Services.AddScoped<ISmsService, SmsService>();

// Config serilog
builder.Services.AddConfigureSerilog(builder.Configuration);
builder.Services.AddSingleton<ILoggingService, LoggingService>();
builder.Host.UseSerilogLogging();

// config jwt
builder.Services.AddAuthenticationJWT(builder.Configuration);
// Jwt injection
builder.Services.AddScoped<IJwtService, JwtService>();

// config EntityFrameWork core
builder.Services.AddEntityFrameWorkCore(builder.Configuration);

// Attribute cache
builder.Services.AddConfigureCache(builder.Configuration);
// Attribute injection
builder.Services.AddSingleton<IResponseCacheService, ResponseCacheService>();



builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();
}



// Enable CORS
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();
IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;
app.UseRouting();
app.MapControllers();
app.UseAuthentication();
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHub<MessageHub>("/hubs/chat");
app.MapGet("/health", () => Results.Ok("OK"));
app.Run();

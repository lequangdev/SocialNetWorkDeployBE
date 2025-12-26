using DataAccessLayer;
using DataAccessLayer.EF_core;
using DataAccessLayer.Interfaces;
using Infrastructure.DependencyInjection.Extentions;
using Infrastructure.Jwt;
using Infrastructure.MediatR;
using Infrastructure.RabitMq.MessageBus.ConsumerService;
using Infrastructure.RabitMq.MessageBus.ConsumerService.Interface;
using Infrastructure.RabitMq.MessageBus.Producers;
using Infrastructure.Redis;
using Infrastructure.Serilog;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;
using ServiceLayer.Interfaces;

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


builder.Services.AddControllers();
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
// add MediatR
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddTransient<IDispatcher, MediatRService>();
// DI multi layer
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IFriendshipService, FriendshipService>();
builder.Services.AddScoped<IFriendshipRepo, FriendshipRepo>();

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
//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
app.MapMethods("/health", new[] { "GET", "HEAD" }, () => Results.Ok());
app.Run();


using Infrastructure.DependencyInjection.Extentions;
using Infrastructure.Jwt;
using Infrastructure.RabitMq.MessageBus.ConsumerService.Interface;
using Infrastructure.RabitMq.MessageBus.ConsumerService;
using Infrastructure.Serilog;
using Infrastructure.Redis;
using DataAccessLayer.EF_core;
using Infrastructure.RabitMq.MessageBus.Producers;
using ServiceLayer.Interfaces;
using ServiceLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

// DI layer 
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostRepo, PostRepo>();
builder.Services.AddScoped<IPost_mediaRepo, Post_mediaRepo>();




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


//app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.MapMethods("/health", new[] { "GET", "HEAD" }, () => Results.Ok());
app.Run();

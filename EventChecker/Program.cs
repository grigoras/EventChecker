using EventChecker.Domain.Models;
using EventChecker.Infrastructure;
using System.Threading.Channels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(Channel.CreateUnbounded<EventModel>(new UnboundedChannelOptions() { SingleReader = true }));
builder.Services.AddSingleton(svc => svc.GetRequiredService<Channel<EventModel>>().Reader);
builder.Services.AddSingleton(svc => svc.GetRequiredService<Channel<EventModel>>().Writer);

builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

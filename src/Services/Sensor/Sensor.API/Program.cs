using Sensor.Application;
using Sensor.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.Run();

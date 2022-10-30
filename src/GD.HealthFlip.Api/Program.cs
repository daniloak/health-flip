using Ardalis.ListStartupServices;
using GD.HealthFlip.Api;
using GD.HealthFlip.Api.Extensions;
using GD.HealthFlip.Api.Providers;
using GD.HealthFlip.Application;
using GD.HealthFlip.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppConections(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<ServiceConfig>(config =>
{
  config.Services = new List<ServiceDescriptor>(builder.Services);
  
  config.Path = "/listservices";
});

builder.Services.AddApplicationDependencies(builder.Configuration);
builder.Services.AddInfrastructureDependencies(builder.Configuration);

builder.Services.AddApiVersioning(options =>
{
  options.ErrorResponses = new ApiVersioningErrorResponseProvider();
});

builder.Services.AddSwaggerConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseShowAllServicesMiddleware();
  app.UseSwaggerConfig();
}

app.UseHttpsRedirection();

//app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();

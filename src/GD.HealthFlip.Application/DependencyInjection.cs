using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GD.HealthFlip.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddMediatR(Assembly.GetExecutingAssembly());
    
    return services;
  }
}

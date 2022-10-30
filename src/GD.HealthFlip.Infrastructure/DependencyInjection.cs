using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GD.HealthFlip.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("HealthFlipDb");
    services.AddDbContext<HealthFlipDbContext>(
      opt => opt.UseMySql(
       connectionString,
       ServerVersion.AutoDetect(connectionString)));
    
    return services;
  }
}

using GD.HealthFlip.Infra.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace GD.HealthFlip.Api.Configurations;

public static class ConnectionsConfiguration
{
    public static IServiceCollection AddAppConections(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbConnection(configuration);
        return services;
    }

    private static IServiceCollection AddDbConnection(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration
            .GetConnectionString("HealthFlipDb");
        services.AddDbContext<HealthFlipDbContext>(
            options => options.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            )
        );
        return services;
    }
}

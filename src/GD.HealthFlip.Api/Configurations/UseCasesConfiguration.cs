using GD.HealthFlip.Application.Interfaces;
using GD.HealthFlip.Application.UseCases.Order.ListOrders;
using GD.HealthFlip.Domain.Repositories;
using GD.HealthFlip.Infra.Data.EF;
using GD.HealthFlip.Infra.Data.EF.Repositories;
using MediatR;

namespace GD.HealthFlip.Api.Configurations;

public static class UseCasesConfiguration
{
    public static IServiceCollection AddUseCases(
        this IServiceCollection services
    )
    {
        services.AddMediatR(typeof(ListOrders));
        services.AddRepositories();
        return services;
    }

    private static IServiceCollection AddRepositories(
            this IServiceCollection services
        )
    {
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
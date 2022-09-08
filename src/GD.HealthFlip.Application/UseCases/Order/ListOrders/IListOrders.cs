using MediatR;

namespace GD.HealthFlip.Application.UseCases.Order.ListOrders;
public interface IListOrders
    : IRequestHandler<ListOrdersInput, ListOrdersOutput>
{ }

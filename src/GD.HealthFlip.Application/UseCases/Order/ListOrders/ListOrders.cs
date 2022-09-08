using GD.HealthFlip.Application.UseCases.Order.Common;
using GD.HealthFlip.Domain.Repositories;

namespace GD.HealthFlip.Application.UseCases.Order.ListOrders;
public class ListOrders : IListOrders
{
    private readonly IOrderRepository _orderRepository;

    public ListOrders(IOrderRepository categoryRepository)
        => _orderRepository = categoryRepository;

    public async Task<ListOrdersOutput> Handle(
        ListOrdersInput request,
        CancellationToken cancellationToken)
    {
        var searchOutput = await _orderRepository.Search(
            new(
                request.Page,
                request.PerPage,
                request.Search,
                request.Sort,
                request.Direction
            ),
            cancellationToken
        );

        return new ListOrdersOutput(
            searchOutput.CurrentPage,
            searchOutput.PerPage,
            searchOutput.Total,
            searchOutput.Items
                .Select(OrderModelOutput.FromOrder)
                .ToList()
        );
    }
}

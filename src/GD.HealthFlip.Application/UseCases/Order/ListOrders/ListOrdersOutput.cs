using GD.HealthFlip.Application.Common;
using GD.HealthFlip.Application.UseCases.Order.Common;

namespace GD.HealthFlip.Application.UseCases.Order.ListOrders;
public class ListOrdersOutput
    : PaginationListOutput<OrderModelOutput>
{
    public ListOrdersOutput(
        int page,
        int perPage,
        int total,
        IReadOnlyList<OrderModelOutput> items)
        : base(page, perPage, total, items)
    {
    }
}

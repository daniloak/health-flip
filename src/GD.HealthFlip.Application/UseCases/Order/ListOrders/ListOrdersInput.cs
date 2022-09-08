using GD.HealthFlip.Application.Common;
using GD.HealthFlip.Domain.SeedWork.SearchableRepository;
using MediatR;

namespace GD.HealthFlip.Application.UseCases.Order.ListOrders;
public class ListOrdersInput
    : PaginationListInput, IRequest<ListOrdersOutput>
{
    public ListOrdersInput(
        int page = 1,
        int perPage = 15,
        string search = "",
        string sort = "",
        SearchOrder dir = SearchOrder.Asc
    ) : base(page, perPage, search, sort, dir)
    { }

    public ListOrdersInput()
        : base(1, 15, "", "", SearchOrder.Asc)
    { }
}

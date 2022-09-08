using GD.HealthFlip.Api.ApiModels.Response;
using GD.HealthFlip.Application.UseCases.Order.Common;
using GD.HealthFlip.Application.UseCases.Order.ListOrders;
using GD.HealthFlip.Domain.SeedWork.SearchableRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GD.HealthFlip.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(typeof(ListOrdersOutput), StatusCodes.Status200OK)]
    public async Task<IActionResult> List(
        CancellationToken cancellationToken,
        [FromQuery] int? page = null,
        [FromQuery(Name = "per_page")] int? perPage = null,
        [FromQuery] string? search = null,
        [FromQuery] string? sort = null,
        [FromQuery] SearchOrder? direction = null
    )
    {
        var input = new ListOrdersInput();
        if (page is not null) input.Page = page.Value;
        if (perPage is not null) input.PerPage = perPage.Value;
        if (!String.IsNullOrWhiteSpace(search)) input.Search = search;
        if (!String.IsNullOrWhiteSpace(sort)) input.Sort = sort;
        if (direction is not null) input.Direction = direction.Value;

        var output = await _mediator.Send(input, cancellationToken);
        return Ok(
            new ApiResponseList<OrderModelOutput>(output)
        );
    }
}

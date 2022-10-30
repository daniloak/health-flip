using GD.HealthFlip.Api.ApiModels;
using GD.HealthFlip.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GD.HealthFlip.Api.Controllers.v1;

[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
public class OrderController : MainController
{
  [HttpGet]
  public async Task<ActionResult<IList<OrderDto>>> GetAll()
  {
    var orders = await Mediator.Send(new GetOrders());

    return Ok(orders.Value);
  }
}

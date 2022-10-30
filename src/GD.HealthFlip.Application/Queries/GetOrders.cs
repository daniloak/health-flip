using Ardalis.Result;
using MediatR;

namespace GD.HealthFlip.Application.Queries;

public class GetOrders : IRequest<Result<IEnumerable<GetOrders>>>
{
  public string Description { get; set; }
}

public class GetOrdersHandler : IRequestHandler<GetOrders, Result<IEnumerable<GetOrders>>>
{
  public async Task<Result<IEnumerable<GetOrders>>> Handle(GetOrders request, CancellationToken cancellationToken)
  {
    return await Task.FromResult(
      Result.Success(
        new List<GetOrders>() { new GetOrders() { Description = "asdasda" } }
          .AsEnumerable()));
  }
}

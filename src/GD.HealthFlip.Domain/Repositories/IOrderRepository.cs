using GD.HealthFlip.Domain.Entity;
using GD.HealthFlip.Domain.SeedWork;
using GD.HealthFlip.Domain.SeedWork.SearchableRepository;

namespace GD.HealthFlip.Domain.Repositories;
public interface IOrderRepository
    : IGenericRepository<Order>,
    ISearchableRepository<Order>
{
    public Task<IReadOnlyList<Guid>> GetIdsListByIds(
        List<Guid> ids,
        CancellationToken cancellationToken
    );

    public Task<IReadOnlyList<Order>> GetListByIds(
        List<Guid> ids,
        CancellationToken cancellationToken
    );
}

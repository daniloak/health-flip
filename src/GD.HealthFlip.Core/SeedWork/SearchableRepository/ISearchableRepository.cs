using GD.HealthFlip.Cpre.SeedWork;

namespace GD.HealthFlip.Core.SeedWork.SearchableRepository;
public interface ISearchableRepository<TAggregate>
    where TAggregate : AggregateRoot
{
    Task<SearchOutput<TAggregate>> Search(
        SearchInput input,
        CancellationToken cancellationToken
    );
}

using GD.HealthFlip.Application.Exceptions;
using GD.HealthFlip.Domain.Entity;
using GD.HealthFlip.Domain.Repositories;
using GD.HealthFlip.Domain.SeedWork.SearchableRepository;
using Microsoft.EntityFrameworkCore;

namespace GD.HealthFlip.Infra.Data.EF.Repositories;
public class OrderRepository
    : IOrderRepository
{
    private readonly HealthFlipDbContext _context;
    private DbSet<Order> _orders
        => _context.Set<Order>();

    public OrderRepository(HealthFlipDbContext context)
        => _context = context;

    public async Task Insert(
        Order aggregate,
        CancellationToken cancellationToken
    )
        => await _orders.AddAsync(aggregate, cancellationToken);

    public async Task<Order> Get(Guid id, CancellationToken cancellationToken)
    {
        var category = await _orders.AsNoTracking().FirstOrDefaultAsync(
            x => x.Id == id,
            cancellationToken
        );
        NotFoundException.ThrowIfNull(category, $"Category '{id}' not found.");
        return category!;
    }

    public Task Update(Order aggregate, CancellationToken _)
        => Task.FromResult(_orders.Update(aggregate));

    public Task Delete(Order aggregate, CancellationToken _)
        => Task.FromResult(_orders.Remove(aggregate));

    public async Task<SearchOutput<Order>> Search(
        SearchInput input,
        CancellationToken cancellationToken)
    {
        var toSkip = (input.Page - 1) * input.PerPage;
        var query = _orders.AsNoTracking();
        query = AddOrderToQuery(query, input.OrderBy, input.Order);
        if (!string.IsNullOrWhiteSpace(input.Search))
            query = query.Where(x => x.Comments.Contains(input.Search));
        var total = await query.CountAsync();
        var items = await query
            .Skip(toSkip)
            .Take(input.PerPage)
            .ToListAsync();

        return new(input.Page, input.PerPage, total, items);
    }

    private IQueryable<Order> AddOrderToQuery(
        IQueryable<Order> query,
        string orderProperty,
        SearchOrder order
    )
    {
        var orderedQuery = (orderProperty.ToLower(), order) switch
        {
            ("comments", SearchOrder.Asc) => query.OrderBy(x => x.Comments)
                .ThenBy(x => x.Id),
            ("comments", SearchOrder.Desc) => query.OrderByDescending(x => x.Comments)
                .ThenByDescending(x => x.Id),
            ("id", SearchOrder.Asc) => query.OrderBy(x => x.Id),
            ("id", SearchOrder.Desc) => query.OrderByDescending(x => x.Id),
            ("createdat", SearchOrder.Asc) => query.OrderBy(x => x.CreatedAt),
            ("createdat", SearchOrder.Desc) => query.OrderByDescending(x => x.CreatedAt),
            _ => query.OrderBy(x => x.Id)
                .ThenBy(x => x.Id)
        };

        return orderedQuery;
    }

    public async Task<IReadOnlyList<Guid>> GetIdsListByIds(
        List<Guid> ids,
        CancellationToken cancellationToken
    )
        => await _orders.AsNoTracking()
            .Where(category => ids.Contains(category.Id))
            .Select(category => category.Id).ToListAsync();

    public async Task<IReadOnlyList<Order>> GetListByIds(List<Guid> ids, CancellationToken cancellationToken)
        => await _orders.AsNoTracking()
            .Where(category => ids.Contains(category.Id))
            .ToListAsync();
}

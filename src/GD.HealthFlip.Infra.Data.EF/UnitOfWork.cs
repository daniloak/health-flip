using GD.HealthFlip.Application.Interfaces;

namespace GD.HealthFlip.Infra.Data.EF;
public class UnitOfWork
    : IUnitOfWork
{
    private readonly HealthFlipDbContext _context;

    public UnitOfWork(HealthFlipDbContext context)
        => _context = context;

    public Task Commit(CancellationToken cancellationToken)
        => _context.SaveChangesAsync(cancellationToken);

    public Task Rollback(CancellationToken cancellationToken)
        => Task.CompletedTask;
}

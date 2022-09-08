using GD.HealthFlip.Domain.Entity;
using GD.HealthFlip.Infra.Data.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GD.HealthFlip.Infra.Data.EF;
public class HealthFlipDbContext
    : DbContext
{
    public DbSet<Order> Orders => Set<Order>();

    public HealthFlipDbContext(
        DbContextOptions<HealthFlipDbContext> options
    ) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new OrderConfiguration());
    }
}

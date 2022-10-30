using GD.HealthFlip.Core.Entities;
using GD.HealthFlip.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GD.HealthFlip.Infrastructure;

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


using GD.HealthFlip.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GD.HealthFlip.Infrastructure.Data.Configuration;

internal class OrderConfiguration
  : IEntityTypeConfiguration<Order>
{
  public void Configure(EntityTypeBuilder<Order> builder)
  {
    builder.HasKey(order => order.Id);
    builder.Property(order => order.Comments)
      .HasMaxLength(255);
  }
}

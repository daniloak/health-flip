using GD.HealthFlip.Cpre.SeedWork;

namespace GD.HealthFlip.Core.Entities;

public class Order : AggregateRoot
{
  public bool IsActive { get; private set; }
  public DateTime CreatedAt { get; private set; }
  public string Comments { get; private set; }

  public Order(string? comments = null, bool isActive = true)
    : base()
  {
    IsActive = isActive;
    CreatedAt = DateTime.UtcNow;
    Comments = comments!;
  }
}

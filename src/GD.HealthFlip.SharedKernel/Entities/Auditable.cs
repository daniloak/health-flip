namespace GD.HealthFlip.SharedKernel.Entities;

public abstract class Auditable
{
  public Auditable() { }

  public Guid Id { get; protected set; }
  public Guid CreatedBy { get; private set; }
  public DateTime CreatedDate { get; private set; }
  public Guid LastModifiedBy { get; private set; }
  public DateTime LastModified { get; private set; }
}

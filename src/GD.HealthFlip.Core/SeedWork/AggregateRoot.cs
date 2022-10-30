using GD.HealthFlip.SharedKernel.Entities;

namespace GD.HealthFlip.Cpre.SeedWork;
public abstract class AggregateRoot : Auditable
{
    protected AggregateRoot() : base() { }
}

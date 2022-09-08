using GD.HealthFlip.Domain.Exceptions;
using GD.HealthFlip.Domain.SeedWork;

namespace GD.HealthFlip.Domain.Entity;
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

        Validate();
    }

    public void Activate()
    {
        IsActive = true;
        Validate();
    }

    public void Deactivate()
    {
        IsActive = false;
        Validate();
    }

    public void Update(string comments)
    {
        Comments = comments;
        Validate();
    }

    private void Validate()
    {
        if (Comments?.Length > 100)
        {
            throw new EntityValidationException("Comments should be less or equal to 100 characters long");
        }
    }
}

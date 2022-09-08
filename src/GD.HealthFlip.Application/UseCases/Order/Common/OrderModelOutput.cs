using DomainEntity = GD.HealthFlip.Domain.Entity;

namespace GD.HealthFlip.Application.UseCases.Order.Common;
public class OrderModelOutput
{
    public Guid Id { get; set; }
    public string Comments { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

    public OrderModelOutput(
        Guid id,
        string comments,
        bool isActive,
        DateTime createdAt
    )
    {
        Id = id;
        Comments = comments;
        IsActive = isActive;
        CreatedAt = createdAt;
    }

    public static OrderModelOutput FromOrder(DomainEntity.Order order)
        => new(
            order.Id,
            order.Comments,
            order.IsActive,
            order.CreatedAt
        );
}

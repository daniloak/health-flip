namespace GD.HealthFlip.UnitTests.Domain.Entity.Order;

using FluentAssertions;
using GD.HealthFlip.Domain.Exceptions;
using DomainEntity = GD.HealthFlip.Domain.Entity;

[Collection(nameof(OrderTestFixture))]
public class OrderTests
{
    private readonly OrderTestFixture _orderTestFixture;

    public OrderTests(OrderTestFixture orderTestFixture)
    {
        _orderTestFixture = orderTestFixture;
    }

    [Fact(DisplayName = nameof(Instantiate))]
    [Trait("Domain", "Order - Aggregates")]
    public void Instantiate()
    {
        var datetimeBefore = DateTime.UtcNow;

        var validOrder = _orderTestFixture.GetValidOrder();
        var order = new DomainEntity.Order(validOrder.Comments);

        var datetimeAfter = DateTime.UtcNow;

        order.Should().NotBeNull();
        order.Id.Should().NotBeEmpty();
        order.Comments.Should().Be(validOrder.Comments);
        order.CreatedAt.Should().NotBeSameDateAs(default(DateTime));
        (order.CreatedAt > datetimeBefore).Should().BeTrue();
        (order.CreatedAt < datetimeAfter).Should().BeTrue();
        order.IsActive.Should().BeTrue();
    }

    [Theory(DisplayName = nameof(InstantiateWithIsActive))]
    [Trait("Domain", "Order - Aggregates")]
    [InlineData(true)]
    [InlineData(false)]
    public void InstantiateWithIsActive(bool isActive)
    {
        var datetimeBefore = DateTime.UtcNow;

        var validOrder = _orderTestFixture.GetValidOrder();
        var order = new DomainEntity.Order(validOrder.Comments, isActive);

        var datetimeAfter = DateTime.UtcNow;

        order.Should().NotBeNull();
        order.Id.Should().NotBeEmpty();
        order.Comments.Should().Be(validOrder.Comments);
        order.CreatedAt.Should().NotBeSameDateAs(default(DateTime));
        (order.CreatedAt > datetimeBefore).Should().BeTrue();
        (order.CreatedAt < datetimeAfter).Should().BeTrue();
        order.IsActive.Should().Be(isActive);
    }

    [Fact(DisplayName = nameof(InstantiateErrorWhenCommentsIsGreaterThan100Characteres))]
    [Trait("Domain", "Order - Aggregates")]
    public void InstantiateErrorWhenCommentsIsGreaterThan100Characteres()
    {
        var invalidComment = String.Join(null, Enumerable.Range(0, 101).Select(_ => "a").ToArray());
        Action action =
            () => new DomainEntity.Order(invalidComment);

        action.Should().Throw<EntityValidationException>()
            .WithMessage("Comments should be less or equal to 100 characters long");
    }

    [Fact(DisplayName = nameof(Activate))]
    [Trait("Domain", "Order - Aggregates")]
    public void Activate()
    {
        var order = new DomainEntity.Order(null, false);
        order.Activate();

        order.IsActive.Should().BeTrue();
    }

    [Fact(DisplayName = nameof(Deactivate))]
    [Trait("Domain", "Order - Aggregates")]
    public void Deactivate()
    {
        var order = new DomainEntity.Order(null, true);
        order.Deactivate();

        order.IsActive.Should().BeFalse();
    }

    [Fact(DisplayName = nameof(Update))]
    [Trait("Domain", "Order - Aggregates")]
    public void Update()
    {
        var order = new DomainEntity.Order("My Comment");
        var newValues = new { Comments = "New Comment" };

        order.Update(newValues.Comments);

        order.Comments.Should().BeSameAs(newValues.Comments);
    }

    [Fact(DisplayName = nameof(UpdateErrorWhenCommentsIsGreaterThan100Characteres))]
    [Trait("Domain", "Order - Aggregates")]
    public void UpdateErrorWhenCommentsIsGreaterThan100Characteres()
    {
        var order = new DomainEntity.Order("my comment");
        var invalidComment = String.Join(null, Enumerable.Range(0, 101).Select(_ => "a").ToArray());
        
        Action action =
            () => order.Update(invalidComment);

        action.Should().Throw<EntityValidationException>()
           .WithMessage("Comments should be less or equal to 100 characters long");
    }
}

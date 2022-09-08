using GD.HealthFlip.UnitTests.Common;
using DomainEntity = GD.HealthFlip.Domain.Entity;

namespace GD.HealthFlip.UnitTests.Domain.Entity.Order;
public class OrderTestFixture : BaseFixture
{
	public OrderTestFixture() : base()
	{
	}

    public DomainEntity.Order GetValidOrder() => new DomainEntity.Order("my comment");
}

[CollectionDefinition(nameof(OrderTestFixture))]
public class OrderTestFixtureCollection : ICollectionFixture<OrderTestFixture>
{

}

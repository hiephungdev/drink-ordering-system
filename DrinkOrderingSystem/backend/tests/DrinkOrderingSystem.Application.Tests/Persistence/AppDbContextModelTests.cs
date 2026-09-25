using DrinkOrderingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DrinkOrderingSystem.Application.Tests.Persistence;

public sealed class AppDbContextModelTests
{
    [Fact]
    public void Model_configures_order_relationships_with_expected_delete_behaviors()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql("Host=localhost;Database=drinkordering;Username=postgres;Password=postgres")
            .Options;

        using var context = new AppDbContext(options);

        var orderTableForeignKey = context.Model.FindEntityType(typeof(Domain.Entities.Order))!
            .GetForeignKeys()
            .Single(foreignKey => foreignKey.PrincipalEntityType.ClrType == typeof(Domain.Entities.Table));
        var orderItemForeignKey = context.Model.FindEntityType(typeof(Domain.Entities.OrderItem))!
            .GetForeignKeys()
            .Single(foreignKey => foreignKey.PrincipalEntityType.ClrType == typeof(Domain.Entities.Order));

        Assert.Equal(DeleteBehavior.Restrict, orderTableForeignKey.DeleteBehavior);
        Assert.Equal(DeleteBehavior.Cascade, orderItemForeignKey.DeleteBehavior);
    }
}
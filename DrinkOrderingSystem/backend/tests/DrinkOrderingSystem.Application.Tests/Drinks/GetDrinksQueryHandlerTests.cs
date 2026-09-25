using DrinkOrderingSystem.Application.Drinks.Queries;
using DrinkOrderingSystem.Domain.Entities;
using DrinkOrderingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DrinkOrderingSystem.Application.Tests.Drinks;

public sealed class GetDrinksQueryHandlerTests
{
    [Fact]
    public async Task Returns_available_drinks_for_requested_category()
    {
        var categoryId = Guid.NewGuid();
        var otherCategoryId = Guid.NewGuid();
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        await using var context = new AppDbContext(options);
        context.Categories.AddRange(
            new Category { Id = categoryId, Name = "Coffee" },
            new Category { Id = otherCategoryId, Name = "Tea" });
        context.Drinks.AddRange(
            new Drink { Name = "Latte", Price = 3.5m, CategoryId = categoryId, IsAvailable = true },
            new Drink { Name = "Sold out", Price = 4m, CategoryId = categoryId, IsAvailable = false },
            new Drink { Name = "Green tea", Price = 2.5m, CategoryId = otherCategoryId, IsAvailable = true });
        await context.SaveChangesAsync();

        var handler = new GetDrinksQueryHandler(context);
        var result = await handler.Handle(new GetDrinksQuery(categoryId), CancellationToken.None);

        var drink = Assert.Single(result);
        Assert.Equal("Latte", drink.Name);
        Assert.Equal(3.5m, drink.Price);
    }
}
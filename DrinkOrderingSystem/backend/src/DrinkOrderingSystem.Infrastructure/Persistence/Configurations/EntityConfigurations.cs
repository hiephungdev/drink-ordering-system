using DrinkOrderingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrinkOrderingSystem.Infrastructure.Persistence.Configurations;

public sealed class DrinkConfiguration : IEntityTypeConfiguration<Drink>
{
    public void Configure(EntityTypeBuilder<Drink> builder)
    {
        builder.Property(drink => drink.Name).HasMaxLength(200).IsRequired();
        builder.Property(drink => drink.Price).HasPrecision(18, 2);
    }
}

public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(category => category.Name).HasMaxLength(100).IsRequired();
    }
}

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(order => order.TotalPrice).HasPrecision(18, 2);
        builder.Property(order => order.Status).HasConversion<string>();
    }
}

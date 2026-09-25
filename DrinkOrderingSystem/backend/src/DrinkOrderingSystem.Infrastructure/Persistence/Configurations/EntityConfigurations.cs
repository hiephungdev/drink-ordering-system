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

        builder.HasOne(drink => drink.Category)
            .WithMany(category => category.Drinks)
            .HasForeignKey(drink => drink.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(category => category.Name).HasMaxLength(100).IsRequired();
        builder.HasIndex(category => category.Name).IsUnique();
    }
}

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(order => order.TotalPrice).HasPrecision(18, 2);
        builder.Property(order => order.Status).HasConversion<string>();
        builder.Property(order => order.CreatedAt).IsRequired();

        builder.HasOne(order => order.Table)
            .WithMany(table => table.Orders)
            .HasForeignKey(order => order.TableId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(order => order.Items)
            .WithOne(item => item.Order)
            .HasForeignKey(item => item.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.Property(item => item.Quantity).IsRequired();
        builder.Property(item => item.Note).HasMaxLength(500);

        builder.HasOne(item => item.Drink)
            .WithMany()
            .HasForeignKey(item => item.DrinkId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public sealed class TableConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.Property(table => table.TableNumber).IsRequired();
        builder.Property(table => table.QrCode).HasMaxLength(500).IsRequired();
        builder.HasIndex(table => table.TableNumber).IsUnique();
        builder.HasIndex(table => table.QrCode).IsUnique();
    }
}

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user => user.Username).HasMaxLength(100).IsRequired();
        builder.Property(user => user.PasswordHash).HasMaxLength(500).IsRequired();
        builder.Property(user => user.Role).HasMaxLength(50).IsRequired();
        builder.HasIndex(user => user.Username).IsUnique();
    }
}

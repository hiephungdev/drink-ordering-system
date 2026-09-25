using DrinkOrderingSystem.Application.Common.Interfaces;
using DrinkOrderingSystem.Domain.Entities;
using DrinkOrderingSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DrinkOrderingSystem.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IUnitOfWork, IApplicationDbContext
{
    public DbSet<Drink> Drinks => Set<Drink>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Table> Tables => Set<Table>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

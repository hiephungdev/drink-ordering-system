using DrinkOrderingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrinkOrderingSystem.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Drink> Drinks { get; }
    DbSet<Category> Categories { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
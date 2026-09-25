using DrinkOrderingSystem.Domain.Common;

namespace DrinkOrderingSystem.Domain.Entities;

public class Drink : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public Guid CategoryId { get; set; }
    public bool IsAvailable { get; set; } = true;
    public Category? Category { get; set; }
}
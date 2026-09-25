using DrinkOrderingSystem.Domain.Common;

namespace DrinkOrderingSystem.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Drink> Drinks { get; set; } = new List<Drink>();
}
using DrinkOrderingSystem.Domain.Common;

namespace DrinkOrderingSystem.Domain.Entities;

public class Table : BaseEntity
{
    public int TableNumber { get; set; }
    public string QrCode { get; set; } = string.Empty;
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
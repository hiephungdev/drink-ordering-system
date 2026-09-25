using DrinkOrderingSystem.Domain.Common;

namespace DrinkOrderingSystem.Domain.Entities;

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; set; }
    public Guid DrinkId { get; set; }
    public int Quantity { get; set; }
    public string? Note { get; set; }
    public Order? Order { get; set; }
    public Drink? Drink { get; set; }
}
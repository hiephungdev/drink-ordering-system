using DrinkOrderingSystem.Domain.Common;
using DrinkOrderingSystem.Domain.Enums;

namespace DrinkOrderingSystem.Domain.Entities;

public class Order : BaseEntity
{
    public Guid TableId { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public decimal TotalPrice { get; set; }
    public Table? Table { get; set; }
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}
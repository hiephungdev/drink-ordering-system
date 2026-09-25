using DrinkOrderingSystem.Domain.Enums;

namespace DrinkOrderingSystem.Application.Orders.DTOs;

public sealed record OrderDto(Guid Id, Guid TableId, OrderStatus Status, DateTime CreatedAt, decimal TotalPrice);

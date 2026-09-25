using MediatR;
using DrinkOrderingSystem.Application.Orders.DTOs;

namespace DrinkOrderingSystem.Application.Orders.Commands;

public sealed record CreateOrderCommand(Guid TableId) : IRequest<OrderDto>;

using MediatR;
using DrinkOrderingSystem.Application.Drinks.DTOs;

namespace DrinkOrderingSystem.Application.Drinks.Queries;

public sealed record GetDrinksQuery(Guid? CategoryId = null) : IRequest<IReadOnlyList<DrinkDto>>;

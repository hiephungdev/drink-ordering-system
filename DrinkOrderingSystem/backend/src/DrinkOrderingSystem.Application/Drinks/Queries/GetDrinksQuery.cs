using MediatR;
using DrinkOrderingSystem.Application.Drinks.DTOs;

namespace DrinkOrderingSystem.Application.Drinks.Queries;

public sealed record GetDrinksQuery : IRequest<IReadOnlyList<DrinkDto>>;

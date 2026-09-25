using DrinkOrderingSystem.Application.Categories.DTOs;
using MediatR;

namespace DrinkOrderingSystem.Application.Categories.Queries;

public sealed record GetCategoriesQuery : IRequest<IReadOnlyList<CategoryDto>>;
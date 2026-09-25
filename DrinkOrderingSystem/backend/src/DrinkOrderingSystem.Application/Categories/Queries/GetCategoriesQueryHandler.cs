using DrinkOrderingSystem.Application.Categories.DTOs;
using DrinkOrderingSystem.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DrinkOrderingSystem.Application.Categories.Queries;

public sealed class GetCategoriesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCategoriesQuery, IReadOnlyList<CategoryDto>>
{
    public async Task<IReadOnlyList<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await context.Categories
            .AsNoTracking()
            .OrderBy(category => category.Name)
            .Select(category => new CategoryDto(category.Id, category.Name))
            .ToListAsync(cancellationToken);
    }
}
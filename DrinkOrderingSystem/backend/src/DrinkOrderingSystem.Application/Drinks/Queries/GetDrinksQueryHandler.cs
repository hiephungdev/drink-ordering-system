using DrinkOrderingSystem.Application.Common.Interfaces;
using DrinkOrderingSystem.Application.Drinks.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DrinkOrderingSystem.Application.Drinks.Queries;

public sealed class GetDrinksQueryHandler(IApplicationDbContext context) : IRequestHandler<GetDrinksQuery, IReadOnlyList<DrinkDto>>
{
    public async Task<IReadOnlyList<DrinkDto>> Handle(GetDrinksQuery request, CancellationToken cancellationToken)
    {
        var query = context.Drinks
            .AsNoTracking()
            .Where(drink => drink.IsAvailable);

        if (request.CategoryId.HasValue)
        {
            query = query.Where(drink => drink.CategoryId == request.CategoryId.Value);
        }

        return await query
            .OrderBy(drink => drink.Name)
            .Select(drink => new DrinkDto(
                drink.Id,
                drink.Name,
                drink.Price,
                drink.ImageUrl,
                drink.CategoryId,
                drink.IsAvailable))
            .ToListAsync(cancellationToken);
    }
}
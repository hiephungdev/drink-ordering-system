using DrinkOrderingSystem.Application.Drinks.DTOs;
using DrinkOrderingSystem.Application.Drinks.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DrinkOrderingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class DrinksController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DrinkDto>>> GetAll([FromQuery] Guid? categoryId, CancellationToken cancellationToken, [FromServices] ISender sender)
    {
        return Ok(await sender.Send(new GetDrinksQuery(categoryId), cancellationToken));
    }
}

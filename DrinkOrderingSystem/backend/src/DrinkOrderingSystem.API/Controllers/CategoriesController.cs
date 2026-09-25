using DrinkOrderingSystem.Application.Categories.DTOs;
using DrinkOrderingSystem.Application.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DrinkOrderingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CategoriesController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<CategoryDto>>> GetAll(CancellationToken cancellationToken, [FromServices] ISender sender)
    {
        return Ok(await sender.Send(new GetCategoriesQuery(), cancellationToken));
    }
}

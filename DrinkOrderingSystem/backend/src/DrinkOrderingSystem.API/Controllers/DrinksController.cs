using Microsoft.AspNetCore.Mvc;

namespace DrinkOrderingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class DrinksController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(Array.Empty<object>());
}

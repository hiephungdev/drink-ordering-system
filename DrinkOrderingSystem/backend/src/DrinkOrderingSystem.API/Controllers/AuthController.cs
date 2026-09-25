using Microsoft.AspNetCore.Mvc;

namespace DrinkOrderingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login() => StatusCode(StatusCodes.Status501NotImplemented);
}

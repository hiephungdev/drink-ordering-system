namespace DrinkOrderingSystem.Infrastructure.Identity;

public interface IJwtService
{
    string CreateToken(Guid userId, string username, string role);
}

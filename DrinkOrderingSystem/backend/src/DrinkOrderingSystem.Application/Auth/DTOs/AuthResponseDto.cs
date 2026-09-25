namespace DrinkOrderingSystem.Application.Auth.DTOs;

public sealed record AuthResponseDto(string AccessToken, DateTime ExpiresAt);

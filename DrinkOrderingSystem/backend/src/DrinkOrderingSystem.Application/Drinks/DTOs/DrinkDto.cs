namespace DrinkOrderingSystem.Application.Drinks.DTOs;

public sealed record DrinkDto(Guid Id, string Name, decimal Price, string? ImageUrl, Guid CategoryId, bool IsAvailable);

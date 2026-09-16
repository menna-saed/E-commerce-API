namespace Ecommerce.Application.Identity.Dtos;

public sealed record RegisterRequest(string Email, string Password, string DisplayName);

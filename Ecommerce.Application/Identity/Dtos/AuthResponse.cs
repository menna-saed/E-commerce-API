namespace Ecommerce.Application.Identity.Dtos;

public sealed record AuthResponse(
    Guid UserId,
    string Email,
    string DisplayName,
    IReadOnlyCollection<string> Roles,
    string AccessToken,
    DateTimeOffset ExpiresAt);

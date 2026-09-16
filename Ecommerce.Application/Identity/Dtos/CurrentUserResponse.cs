namespace Ecommerce.Application.Identity.Dtos;

public sealed record CurrentUserResponse(
    Guid UserId,
    string Email,
    string DisplayName,
    IReadOnlyCollection<string> Roles);

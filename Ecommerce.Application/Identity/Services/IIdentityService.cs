using Ecommerce.Application.Identity.Dtos;
using Ecommerce.Domain.Common;

namespace Ecommerce.Application.Identity.Services;

public interface IIdentityService
{
    Task<Result<AuthResponse>> RegisterAsync(RegisterRequest request, CancellationToken ct = default);

    Task<Result<AuthResponse>> LoginAsync(LoginRequest request, CancellationToken ct = default);

    Task<Result<CurrentUserResponse>> GetCurrentUserAsync(Guid userId, CancellationToken ct = default);
    
    Task<Result<bool>> CheckEmailAsync(string email, CancellationToken ct = default);
}

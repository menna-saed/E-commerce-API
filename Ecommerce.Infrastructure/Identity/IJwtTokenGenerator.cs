using Ecommerce.Application.Identity.Dtos;
using ECommerce.Infrastructure.Identity;

namespace Ecommerce.Infrastructure.Identity;

public interface IJwtTokenGenerator
{
    AuthResponse Create(ApplicationUser user, IReadOnlyCollection<string> roles);
}

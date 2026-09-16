using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ecommerce.Application.Identity.Dtos;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ECommerce.Infrastructure.Identity;

namespace Ecommerce.Infrastructure.Identity;
// دا بقا هيستخدم في    في  fun login, reg, auth , authr
public sealed class JwtTokenGenerator(IOptions<JwtOptions> options) : IJwtTokenGenerator
{
    public AuthResponse Create(ApplicationUser user, IReadOnlyCollection<string> roles)
    {
        var jwt = options.Value;
        var expiresAt = DateTimeOffset.UtcNow.AddMinutes(jwt.ExpiryMinutes);
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email ?? string.Empty),
            new(ClaimTypes.Name, user.DisplayName ?? user.Email ?? string.Empty)
        };
//عشان هو list وهو بياخد   string          

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwt.Issuer,
            audience: jwt.Audience,
            claims: claims,
            expires: expiresAt.UtcDateTime,
            signingCredentials: credentials);

        // هنا افضل يرجع infoAboutUser بدل م token فقط
        return new AuthResponse(
            user.Id,
            user.Email ?? string.Empty,
            user.DisplayName ?? string.Empty,
            roles,
            new JwtSecurityTokenHandler().WriteToken(token),
            expiresAt);
    }
}

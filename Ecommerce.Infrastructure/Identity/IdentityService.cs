using Ecommerce.Application.Identity.Dtos;
using Ecommerce.Application.Identity.Services;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.common;
using Ecommerce.Domain.Constans;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ECommerce.Infrastructure.Identity;

namespace Ecommerce.Infrastructure.Identity;

public sealed class IdentityService(
    UserManager<ApplicationUser> userManager,
    IJwtTokenGenerator tokenGenerator) : IIdentityService 
{
    public async Task<Result<AuthResponse>> RegisterAsync(RegisterRequest request, CancellationToken ct = default)
    {
        var email = request.Email.Trim();
        if (await userManager.Users.AnyAsync(user => user.Email == email, ct))
            return Result<AuthResponse>.Failure(UserErrors.EmailAlreadyExists);

        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            DisplayName = request.DisplayName.Trim()
        };

        var createResult = await userManager.CreateAsync(user, request.Password);
        if (!createResult.Succeeded)
            return Result<AuthResponse>.Failure(UserErrors.RegistrationFailed(
                string.Join(" ", createResult.Errors.Select(error => error.Description))));

        var addToRoleResult = await userManager.AddToRoleAsync(user, Roles.User);
        if (!addToRoleResult.Succeeded)
            return Result<AuthResponse>.Failure(UserErrors.RegistrationFailed(
                string.Join(" ", addToRoleResult.Errors.Select(error => error.Description))));

        
        // عشان هو مستني roles كمان ف عملت array قيمه user 
        // او تعملي fun قي interface  تجيب role
        
        var roles = new[] { Roles.User };
        return Result<AuthResponse>.Success(tokenGenerator.Create(user, roles));
    }

    public async Task<Result<AuthResponse>> LoginAsync(LoginRequest request, CancellationToken ct = default)
    {
        var user = await userManager.FindByEmailAsync(request.Email.Trim());
        if (user is null || !await userManager.CheckPasswordAsync(user, request.Password))
            return Result<AuthResponse>.Failure(UserErrors.InvalidCredentials);
// هنا function login محتاجه تعرف login  ف محتاجه تجيب roles
        var roles = (await userManager.GetRolesAsync(user)).ToArray();
        return Result<AuthResponse>.Success(tokenGenerator.Create(user, roles));
    }

    public async Task<Result<CurrentUserResponse>> GetCurrentUserAsync(Guid userId, CancellationToken ct = default)
    {
        var user = await userManager.Users.SingleOrDefaultAsync(user => user.Id == userId, ct);
        if (user is null)
            return Result<CurrentUserResponse >.Failure(UserErrors.NotFound);

        var roles = (await userManager.GetRolesAsync(user)).ToArray();
        return Result<CurrentUserResponse>.Success(new CurrentUserResponse(
            user.Id,
            user.Email ?? string.Empty,
            user.DisplayName ?? string.Empty,
            roles));
        
     
    }

    public async Task<Result<bool>> CheckEmailAsync(string email, CancellationToken ct = default)
    {
        var emailResult = email.Trim();
        if (await userManager.Users.AnyAsync(user => user.Email == emailResult, ct))
            return  Result<bool>.Failure(UserErrors.EmailAlreadyExists);
        
        return  Result<bool>.Success(true);
    }
}

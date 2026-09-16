using Ecommerce.Domain.Constans;
using ECommerce.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Ecommerce.Infrastructure.Seeding;

public  class IdentitySeed(
    RoleManager<ApplicationRole> roleManager ,
    UserManager<ApplicationUser> userManager,
    IConfiguration config)
{


    public async Task SeedAsync(CancellationToken ct = default)
    {
        await SeedRolesAsync(ct);
        await SeedSuperAminAsync(ct);
    }

    private async Task SeedRolesAsync(CancellationToken ct = default)
    {
        foreach (var roleName in Roles.All)
        {
            if (await roleManager.RoleExistsAsync(roleName))
                continue;

            await roleManager.CreateAsync(new ApplicationRole(roleName)
            {
                Description = $"{roleName} system role"
            });
          
        }
    }
    
    private  async Task SeedSuperAminAsync(CancellationToken ct = default)
    {
        var section = config.GetSection("Seed:SuperAdmin");
        var email = section["Email"];
        var password = section["Password"];
        
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            return;

        if (await userManager.Users.AnyAsync(u => u.Email == email, ct))
            return;

        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true
        };
        var result = await userManager.CreateAsync(user, password);

        if (result.Succeeded)
            await userManager.AddToRoleAsync(user, Roles.superAdmin);

    }
}

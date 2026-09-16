using ECommerce.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Identity;

public class AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) 
    : IdentityDbContext<ApplicationUser , ApplicationRole , Guid>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        
        //مهم لل7جداول عشان يظهر ضروري 
        base.OnModelCreating(builder);
        
        builder.ApplyConfigurationsFromAssembly(typeof(AppIdentityDbContext).Assembly,
            type => type.Namespace == "Ecommerce.Infrastructure.Identity" );
        
    }
}
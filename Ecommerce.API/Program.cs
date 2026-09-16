using Ecommerce.API;
using Ecommerce.API.EndPoints;
using Ecommerce.Application;
using Ecommerce.Interface.Seeding;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using Asp.Versioning;
using Asp.Versioning.Conventions;
using Ecommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEcommerceApi(builder.Configuration);


//RateLimiter  For login
/*builder.Services.AddRateLimiter(options =>
{
    options.AddPolicy("login-policy", httpContext =>
    {
        var clientIp =
            httpContext.Connection.RemoteIpAddress?.ToString()
            ?? "unknown";

        return RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: clientIp,
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 5,
                Window = TimeSpan.FromMinutes(1),
                QueueLimit = 0
            });
    });*/

    builder.Services.AddRateLimiter(options =>
    {
        options.AddPolicy("products-policy", httpContext =>
        {
            var clientIp =
                httpContext.Connection.RemoteIpAddress?.ToString()
                ?? "unknown";

            return RateLimitPartition.GetFixedWindowLimiter(
                partitionKey: clientIp,
                factory: _ => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = 10,
                    Window = TimeSpan.FromMinutes(30),
                    QueueLimit = 0
                });
        });

        options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    });



var app = builder.Build();



// RateLimiter
app.UseRateLimiter();
// Seeding
await app.Services.SeedDatabaseAsync();

// Middleware
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Endpoints
app.MapCatalogEndpoints();
app.MapBasketEndpoints();
app.MapIdentityEndpoints();

app.MapHealthChecks("/health");

app.Run();

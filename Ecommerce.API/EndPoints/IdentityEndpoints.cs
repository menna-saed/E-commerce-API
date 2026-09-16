using System.Security.Claims;
using Asp.Versioning;
using Ecommerce.API.Extentions;
using Ecommerce.Application.Identity.Dtos;
using Ecommerce.Application.Identity.Services;

namespace Ecommerce.API.EndPoints;

public static class IdentityEndpoints
{
    public static IEndpointRouteBuilder MapIdentityEndpoints(this IEndpointRouteBuilder app)
    {
        var versionSet = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1.0))
            .ReportApiVersions()
            .Build();

        var identity = app.MapGroup("/api/v{version:apiVersion}/identity")
            .WithApiVersionSet(versionSet)
            .MapToApiVersion(1.0)
            .WithTags("Identity");

        identity.MapPost("/register", async (
            HttpContext context,
            RegisterRequest request,
            IIdentityService identityService,
            CancellationToken ct) =>
        {
            var result = await identityService.RegisterAsync(request, ct);
            return result.IsFailure ? result.ApiProblem(context) : context.ApiOk(result.Value!);
        }).AllowAnonymous();

        identity.MapPost("/login", async (
            HttpContext context,
            LoginRequest request,
            IIdentityService identityService,
            CancellationToken ct) =>
        {
            var result = await identityService.LoginAsync(request, ct);
            return result.IsFailure ? result.ApiProblem(context) : context.ApiOk(result.Value!);
        }).AllowAnonymous();

        identity.MapGet("/me", async (
            HttpContext context,
            ClaimsPrincipal principal,
            IIdentityService identityService,
            CancellationToken ct) =>
        {
            var idValue = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(idValue, out var userId))
                return Results.Unauthorized();

            var result = await identityService.GetCurrentUserAsync(userId, ct);
            return result.IsFailure ? result.ApiProblem(context) : context.ApiOk(result.Value!);
        }).RequireAuthorization();

        return app;
    }
}

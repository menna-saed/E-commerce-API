using Asp.Versioning;
using Ecommerce.API.Extentions;
using Ecommerce.Application.Baskets.Dtos;
using Ecommerce.Application.Baskets.Services;

namespace Ecommerce.API.EndPoints; 

public static class BasketEndpoints
{
    public static IEndpointRouteBuilder MapBasketEndpoints(this IEndpointRouteBuilder app)
    {
        var versionSet = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1.0))
            .ReportApiVersions()
            .Build();

        var baskets = app.MapGroup("/api/v{version:apiVersion}/baskets")
            .WithApiVersionSet(versionSet)
            .MapToApiVersion(1.0);

        baskets.MapGet("/{id:guid}", async (
            HttpContext context,
            Guid id,
            IBasketService basketService,
            CancellationToken ct) =>
        {
            var result = await basketService.GetAsync(id, ct);
            return result.IsFailure
                ? result.ApiProblem(context)
                : context.ApiOk(result.Value!);
        }).RequireAuthorization();

        baskets.MapPut("", async (
            HttpContext context,

            BasketDto basket,
            IBasketService basketService,
            CancellationToken ct) =>
        {
          

            var result = await basketService.CreateOrUpdateAsync (basket, ct);
            return result.IsFailure
                ? result.ApiProblem(context)
                : context.ApiOk(result.Value!);
        });

        baskets.MapDelete("/{id:guid}", async (HttpContext context, Guid id, IBasketService basketService, CancellationToken ct) =>
        {
            var result = await basketService.DeleteAsync(id, ct);
            return result.IsFailure ? result.ApiProblem(context) : Results.NoContent();
        }).RequireAuthorization();

        return app;
    }
}

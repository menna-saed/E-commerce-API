using Ecommerce.Application.Common.Behaviors;
using Ecommerce.Application.Baskets.Services;
using Ecommerce.Application.Caching.Services;
using Ecommerce.Application.Products.Handlers;
using Ecommerce.Application.Products.Validators;
using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(MappingConfig).Assembly);

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<ICacheService, CacheService>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllProductsQueryHandler).Assembly));
        services.AddValidatorsFromAssembly(typeof(GetAllProductsQueryValidator).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}

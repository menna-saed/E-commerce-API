using Ecommerce.Application.Products.Dtos;
using Ecommerce.Domain.common;
using Ecommerce.Domain.Specifications.Products;
using Ecommerce.Infrastructure.Configration.DBcontext;
using Ecommerce.Interface.Presistence.Specifications;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Interface.Presistence.Queries;

public sealed class ProductQueryService(AppDBcontext context) : IProdcutQueryService
{
    public async Task<IReadOnlyList<ProductDto>> GetAllAsync(ProductQueryParameters parameters, CancellationToken ct = default)
    { 
        var specification = new ActiveProductsSpecification(parameters);

        return await context.Products
            .AsNoTracking()
            .ApplySpecification(specification)
            .ProjectToType<ProductDto>()
            .ToListAsync(ct);
    }

    public async Task<ProductDto?> GetById(Guid id, CancellationToken ct = default)
    {
        var specification = new ProductByIdSpecification(id);

        return await context.Products
            .AsNoTracking()
            .ApplySpecification(specification)
            .ProjectToType<ProductDto>()
            .FirstOrDefaultAsync(ct);
    }
}

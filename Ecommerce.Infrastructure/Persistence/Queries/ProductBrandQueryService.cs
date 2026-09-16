using Ecommerce.Application.Brands.Dtos;
using Ecommerce.Domain.Specifications.Brands;
using Ecommerce.Infrastructure.DBcontext;
using Ecommerce.Infrastructure.Persistence.Specifications;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Interface.Presistence.Queries;

public class ProductBrandQueryService(AppDBcontext context) : IProductBrandQueryService
{
    public async Task<IReadOnlyList<BrandDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var specification = new ActiveBrandsSpecification();

        return await context.ProductBrands
            .AsNoTracking()
            .ApplySpecification(specification)
            .ProjectToType<BrandDto>()
            .ToListAsync(cancellationToken);
    }
}

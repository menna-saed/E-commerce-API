using Ecommerce.Application.Types.Dtos;
using Ecommerce.Domain.Specifications.Types;
using Ecommerce.Infrastructure.DBcontext;
using Ecommerce.Infrastructure.Persistence.Specifications;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Interface.Presistence.Queries;

public class ProductTypeQueryService(AppDBcontext context) : IProductTypeQueryService
{
    public async Task<IReadOnlyList<TypeDto>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var specification = new ActiveTypesSpecification();

        return await context.ProductTypes
            .AsNoTracking()
            .ApplySpecification(specification)
            .ProjectToType<TypeDto>()
            .ToListAsync(cancellationToken);
    }
}

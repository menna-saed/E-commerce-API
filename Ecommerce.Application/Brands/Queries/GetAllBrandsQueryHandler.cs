using Ecommerce.Application.Brands.Dtos;
using Ecommerce.Domain.Common;
using MediatR;

namespace Ecommerce.Application.Brands.Queries;

public sealed class GetAllBrandsQueryHandler(IProductBrandQueryService productBrandQueryService)
    : IRequestHandler<GetAllBrandsQuery, Result<IReadOnlyList<BrandDto>>>
{
    public async Task<Result<IReadOnlyList<BrandDto>>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        => Result<IReadOnlyList<BrandDto>>.Success(await productBrandQueryService.GetAllAsync(cancellationToken));
}

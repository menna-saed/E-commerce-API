using Ecommerce.Application.Products.Dtos;
using Ecommerce.Application.Products.Queries;
using Ecommerce.Domain.Common;
using MediatR;

namespace Ecommerce.Application.Products.Handlers;

public sealed class GetAllProductsQueryHandler(IProdcutQueryService productQueryService)
    :IRequestHandler<
                        GetAllProductsQuery,
                        Result<IReadOnlyList<ProductDto>>>
{
    public async Task<Result<IReadOnlyList<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await productQueryService   .GetAllAsync          (
            request.Parameter,
            cancellationToken);

        return Result<IReadOnlyList<ProductDto>>.Success(products);
    }
}
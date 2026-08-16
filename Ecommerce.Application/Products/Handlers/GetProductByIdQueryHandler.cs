using Ecommerce.Application.Products.Dtos;
using Ecommerce.Application.Products.Queries;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Products;
using MediatR;

namespace Ecommerce.Application.Products.Handlers;

public sealed class GetProductByIdQueryHandler(IProdcutQueryService productQueryService)
    : IRequestHandler<GetProductByIdQuery, Result<ProductDto>>
{
    public async Task<Result<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productQueryService.GetById(request.Id, cancellationToken);
        return product is null
            ? Result<ProductDto>.Failure(ProductErrors.NotFound)
            : Result<ProductDto>.Success(product);
    }
}

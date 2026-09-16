using Ecommerce.Application.Products.Dtos;
using Ecommerce.Domain.common;
using Ecommerce.Domain.Common;
using MediatR;

namespace Ecommerce.Application.Products.Queries;

public sealed record GetAllProductsQuery (ProductQueryParameters    Parameter) :
    IRequest<Result<IReadOnlyList<ProductDto>>>
{
    
}
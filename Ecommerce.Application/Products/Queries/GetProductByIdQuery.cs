using Ecommerce.Application.Products.Dtos;
using Ecommerce.Domain.Common;
using MediatR;

namespace Ecommerce.Application.Products.Queries;

public sealed record GetProductByIdQuery(Guid Id) : IRequest<Result<ProductDto>>;

using Ecommerce.Application.Brands.Dtos;
using Ecommerce.Domain.Common;
using MediatR;

namespace Ecommerce.Application.Brands.Queries;

public sealed record GetAllBrandsQuery : IRequest<Result<IReadOnlyList<BrandDto>>>;

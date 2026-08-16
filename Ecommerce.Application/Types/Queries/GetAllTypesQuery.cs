using Ecommerce.Application.Types.Dtos;
using Ecommerce.Domain.Common;
using MediatR;

namespace Ecommerce.Application.Types.Queries;

public sealed record GetAllTypesQuery : IRequest<Result<IReadOnlyList<TypeDto>>>;

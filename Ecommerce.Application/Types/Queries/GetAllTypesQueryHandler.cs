using Ecommerce.Application.Types.Dtos;
using Ecommerce.Domain.Common;
using MediatR;

namespace Ecommerce.Application.Types.Queries;

public sealed class GetAllTypesQueryHandler(IProductTypeQueryService productTypeQueryService)
    : IRequestHandler<GetAllTypesQuery, Result<IReadOnlyList<TypeDto>>>
{
    public async Task<Result<IReadOnlyList<TypeDto>>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        => Result<IReadOnlyList<TypeDto>>.Success(await productTypeQueryService.GetAllAsync(cancellationToken));
}



using Ecommerce.Application.Products.Queries;
using FluentValidation;

namespace Ecommerce.Application.Products.Validators;

public sealed class GetAllProductsQueryValidator
    : AbstractValidator<GetAllProductsQuery>
{
    public GetAllProductsQueryValidator()
    {
        RuleFor(x => x.Parameter)
            .Must(parameters =>
                parameters.PageNumber.HasValue == parameters.PageSize.HasValue)
            .WithMessage("PageNumber and PageSize must be provided together.");

        RuleFor(x => x.Parameter.PageNumber)
            .GreaterThan(0)
            .When(x => x.Parameter.PageNumber.HasValue);

        RuleFor(x => x.Parameter.PageSize)
            .GreaterThan(0)
            .LessThanOrEqualTo(100)
            .When(x => x.Parameter.PageSize.HasValue);
    }
}

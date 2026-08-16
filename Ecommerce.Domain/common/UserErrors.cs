
namespace Ecommerce.Domain.common;

public static class UserErrors
{
    public static readonly Error NotFound = new(
        "User.NotFound",
        "The user was not found.",
        ErrorType.NotFound);

    public static readonly Error InvalidCredentials = new(
        "User.InvalidCredentials",
        "Invalid email or password.",
        ErrorType.Unauthorized);
}

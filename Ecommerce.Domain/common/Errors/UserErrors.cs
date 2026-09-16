
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

    public static readonly Error EmailAlreadyExists = new(
        "User.EmailAlreadyExists",
        "An account with this email already exists.",
        ErrorType.Conflict);

    public static Error RegistrationFailed(string description) => new(
        "User.RegistrationFailed",
        description,
        ErrorType.Validation);
}

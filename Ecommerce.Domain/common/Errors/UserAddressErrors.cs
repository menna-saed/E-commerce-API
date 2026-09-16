

using Ecommerce.Domain.common;

namespace ECommerce.Domain.Errors;

public static class UserAddressErrors
{
    public static readonly Error NotFound =
      new (
            "UserAddress.NotFound",
            "Address was not found.",
            ErrorType.NotFound);

    public static readonly Error InvalidId =
        new(
            "UserAddress.InvalidId",
            "Address id is required.",
            ErrorType.Validation);

    public static readonly Error InvalidUserId =
       new(
            "UserAddress.InvalidUserId",
            "User id is required.",
            ErrorType.Validation);


    public static readonly Error InvalidName =
        new(
            "UserAddress.InvalidName",
            "Recipient name is required.",
            ErrorType.Validation);

    public static readonly Error InvalidPhone =
       new(
            "UserAddress.InvalidPhone",
            "Phone number is required.",
            ErrorType.Validation);

    public static readonly Error InvalidLocation =
       new(
            "UserAddress.InvalidLocation",
            "Country, city and street are required.",
            ErrorType.Validation);

    
}
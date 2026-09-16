namespace Ecommerce.Domain.Constans;

public class Roles
{
    public const string Admin = "Admin";
    public const string User = "User";
    public const string superAdmin = "superAdmin";

    public static readonly IReadOnlyList<string> All =
    [
        Admin,
        User,
         superAdmin
    
        ];

}
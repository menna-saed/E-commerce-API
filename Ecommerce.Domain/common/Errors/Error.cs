namespace Ecommerce.Domain.common;

public sealed class Error
{
    public string Code { get; }
    public string Description { get; }
    public ErrorType Type { get; }

    public Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
    }

}
using Ecommerce.Domain.common;

namespace Ecommerce.Domain.Common;

public class Result
{
    protected Result(bool isSuccess, Error? error = null)
    {
        if (isSuccess && error != null)
            throw new ArgumentException("Success result cannot have an error.");

        if (!isSuccess && error == null)
            throw new ArgumentException("Failure result must have an error.");

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error? Error { get; }

    public static Result Success()
        => new(true);

    public static Result Failure(Error error)
        => new(false, error);
}

public sealed class Result<TValue>: Result
{
    private Result(TValue value, bool isSuccess, Error? error = null)
        : base(isSuccess, error)
    {
        Value = value;
    }
    
    public TValue? Value { get; }

    public static Result<TValue> Success(TValue value)
        => new(value,true);

    public static Result<TValue>  Failure(Error error)
        => new(default!,false, error);

    public TResult Match<TResult>(
        Func<TValue, TResult> onSuccess,
        Func<Error, TResult> onFailure)
    {
        return IsSuccess ? onSuccess (Value!)  : onFailure (Error);
    }
    
}

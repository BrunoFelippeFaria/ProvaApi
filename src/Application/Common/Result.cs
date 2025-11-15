namespace Application.Common;

public class Result<T>
{
    public T? Value { get; set; }
    public Error? Error { get; set; }
    public bool Ok => Error == null;

    private Result(T value)
    {
        Value = value;
    }

    private Result(Error error)
    {
        Error = error;
    }

    public static Result<T> Sucess(T Value)
    {
        return new(Value);        
    }

    public static Result<T> Fail(Error error)
    {
        return new (error);
    }

    public static implicit operator Result<T>(Error error) => Fail(error);
}

public class Result
{
    public Error? Error { get; set; }
    public bool Ok => Error == null;

    private Result(){}

    private Result(Error error)
    {
        Error = error;
    }

    public static Result<T> Sucess<T>(T value)
    {
        return Result<T>.Sucess(value);  
    } 

    public static Result Sucess()
    {
        return new();        
    }

    public static Result<T> Fail<T>(Error error)
    {
        return Result<T>.Fail(error);
    }

    public static Result Fail(Error error)
    {
        return new (error);
    }

    public static implicit operator Result(Error error) => Fail(error);

}
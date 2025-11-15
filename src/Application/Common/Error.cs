namespace Application.Common;

public record Error(int Code, string Msg)
{
    public static Error NotFound(string msg) => new (404, msg);
    public static Error BadRequest(string msg) => new (400, msg);
}
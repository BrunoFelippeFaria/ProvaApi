using Application.Common;
using Microsoft.AspNetCore.Mvc;

public static class ResultExtension
{
    public static IActionResult ToActionResult(this Result result)
    {
        if (result.Ok)
        {
            return new OkResult();
        }        
    
        return new ObjectResult(result)
        {
            Value = result.Error?.Msg,
            StatusCode = MapStatusCode(result.Error!)
        };
    }

    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        if (result.Ok)
        {
            return new OkObjectResult(result.Value);
        }        
    
        return new ObjectResult(result)
        {
            Value = result.Error?.Msg,
            StatusCode = MapStatusCode(result.Error)
        };
    }

    private static int MapStatusCode(Error? error) => error?.Code switch
    {
        404 => StatusCodes.Status404NotFound,
        400 => StatusCodes.Status400BadRequest,
        _ => StatusCodes.Status500InternalServerError
    };
}
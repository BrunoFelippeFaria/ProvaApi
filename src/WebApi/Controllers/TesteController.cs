using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/teste")]
public class TesteController : ControllerBase
{
    [HttpGet]
    public IActionResult Teste()
    {
        return Ok("hello, world!");
    }
}
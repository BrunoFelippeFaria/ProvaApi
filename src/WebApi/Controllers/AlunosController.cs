using System.Threading.Tasks;
using Application.UseCases.Alunos;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/alunos")]
public class TesteController(IMediator mediator) : ControllerBase
{
    private IMediator _mediator = mediator;
 
    [HttpGet]
    public async Task<IActionResult> ConsultarAlunos()
    {
        var alunos = await _mediator.Send(new GetAllAlunosQuery());
        return Ok(alunos);
    }
}
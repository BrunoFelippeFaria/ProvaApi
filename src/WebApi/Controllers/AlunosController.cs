using Application.UseCases.Alunos;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> ConsultarAluno([FromRoute] int id)
    {
        var aluno = await _mediator.Send(new GetAlunoQuery(id));
        return Ok(aluno);
    }
}
using System.Threading.Tasks;
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

    [HttpPost]
    public async Task<IActionResult> AdicionarAluno([FromBody] CreateAlunoCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarAluno([FromRoute] int id)
    {
        await _mediator.Send(new DeleteAlunoCommand(id));
        return Ok();
    }
}
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
        var result = await _mediator.Send(new GetAllAlunosQuery());
        return result.ToActionResult();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ConsultarAluno([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetAlunoQuery(id));
        return result.ToActionResult();
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarAluno([FromBody] CreateAlunoCommand command)
    {
        var result = await _mediator.Send(command);
        return result.ToActionResult();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarAluno([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteAlunoCommand(id));
        return result.ToActionResult();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAluno([FromRoute] int id, [FromBody] UpdateAlunoCommand command)
    {
        var cmd = command with { Id = id };
        var result = await _mediator.Send(cmd);

        return result.ToActionResult();
    }
}
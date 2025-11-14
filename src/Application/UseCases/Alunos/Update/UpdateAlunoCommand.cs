using MediatR;

namespace Application.UseCases.Alunos;

public record UpdateAlunoCommand(int Id) : IRequest<Unit>
{
    public string? Nome { get; set; }
}
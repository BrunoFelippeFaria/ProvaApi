using MediatR;

namespace Application.UseCases.Alunos;

public record CreateAlunoCommand : IRequest<Unit>
{
    public required string Nome { get; init; }
}
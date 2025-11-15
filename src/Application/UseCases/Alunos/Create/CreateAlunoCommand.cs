using Application.Common;
using MediatR;

namespace Application.UseCases.Alunos;

public record CreateAlunoCommand : IRequest<Result>
{
    public required string Nome { get; init; }
}
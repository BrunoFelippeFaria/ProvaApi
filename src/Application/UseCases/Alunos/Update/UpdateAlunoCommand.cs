using Application.Common;
using MediatR;

namespace Application.UseCases.Alunos;

public record UpdateAlunoCommand(int Id) : IRequest<Result>
{
    public string? Nome { get; set; }
}
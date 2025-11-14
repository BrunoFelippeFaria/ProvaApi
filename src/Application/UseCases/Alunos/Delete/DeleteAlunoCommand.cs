using MediatR;

namespace Application.UseCases.Alunos;

public record DeleteAlunoCommand(int Id) : IRequest<Unit>;
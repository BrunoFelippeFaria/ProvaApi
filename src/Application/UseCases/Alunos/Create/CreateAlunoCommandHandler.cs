using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Alunos;

public class CreateAlunoCommandHandler(IAlunosRepository repo) : IRequestHandler<CreateAlunoCommand, Unit>
{
    private readonly IAlunosRepository _repo = repo;

    public async Task<Unit> Handle(CreateAlunoCommand request, CancellationToken cancellationToken)
    {
        Aluno aluno = new()
        {
            Nome = request.Nome
        };

        await _repo.Add(aluno);

        return Unit.Value;
    }
}
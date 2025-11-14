using Application.Interfaces;
using MediatR;

namespace Application.UseCases.Alunos;

public class DeleteAlunoCommandHandler(IAlunosRepository repo) : IRequestHandler<DeleteAlunoCommand, Unit>
{
    private readonly IAlunosRepository _repo = repo;

    public async Task<Unit> Handle(DeleteAlunoCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _repo.GetById(request.Id)
            ?? throw new Exception("Aluno não encontrado");
        
        await _repo.Delete(aluno);

        return Unit.Value;
    }
}
using Application.Common;
using Application.Interfaces;
using MediatR;

namespace Application.UseCases.Alunos;

public class DeleteAlunoCommandHandler(IAlunosRepository repo) : IRequestHandler<DeleteAlunoCommand, Result>
{
    private readonly IAlunosRepository _repo = repo;

    public async Task<Result> Handle(DeleteAlunoCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _repo.GetById(request.Id);

        if (aluno == null)
            return Error.NotFound("Aluno não encontrado");

        await _repo.Delete(aluno);

        return Result.Sucess();
    }
}
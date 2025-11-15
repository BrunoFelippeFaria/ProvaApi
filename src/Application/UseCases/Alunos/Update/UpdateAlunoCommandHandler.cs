using Application.Common;
using Application.Interfaces;
using MediatR;

namespace Application.UseCases.Alunos;

public class UpdateAlunoCommandHandler(IAlunosRepository repo) : IRequestHandler<UpdateAlunoCommand, Result>
{
    private readonly IAlunosRepository _repo = repo;

    public async Task<Result> Handle(UpdateAlunoCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _repo.GetById(request.Id);
        
        if (aluno == null)
            return Error.NotFound("Aluno não encontrado");

        if (!string.IsNullOrEmpty(request.Nome))
            aluno.Nome = request.Nome;

        await _repo.Save();

        return Result.Sucess();
    }
}
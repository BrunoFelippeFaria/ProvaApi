using Application.Interfaces;
using MediatR;

namespace Application.UseCases.Alunos;

public class UpdateAlunoCommandHandler(IAlunosRepository repo) : IRequestHandler<UpdateAlunoCommand, Unit>
{
    private readonly IAlunosRepository _repo = repo;

    public async Task<Unit> Handle(UpdateAlunoCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _repo.GetById(request.Id)
            ?? throw new Exception("Aluno não encontrado");

        if (!string.IsNullOrEmpty(request.Nome))
            aluno.Nome = request.Nome;

        await _repo.Save();
        return Unit.Value;
    }
}
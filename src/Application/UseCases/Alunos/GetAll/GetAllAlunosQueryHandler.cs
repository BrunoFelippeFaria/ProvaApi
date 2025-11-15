using Application.Common;
using Application.Dtos;
using Application.Interfaces;
using MediatR;

namespace Application.UseCases.Alunos;

public class GetAllAlunosQueryHandler(IAlunosRepository repo) : IRequestHandler<GetAllAlunosQuery, Result<IEnumerable<AlunoDto>>>
{
    private readonly IAlunosRepository _repo = repo;

    public async Task<Result<IEnumerable<AlunoDto>>> Handle(GetAllAlunosQuery request, CancellationToken cancellationToken)
    {
        var alunos = await _repo.GetAll();

        List<AlunoDto> alunosDtos = [];

        foreach (var aluno in alunos)
        {
            alunosDtos.Add(AlunoDto.FromEntity(aluno));
        }

        return Result.Sucess(alunosDtos.AsEnumerable());
    }
}
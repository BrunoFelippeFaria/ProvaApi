using Application.Dtos;
using Application.Interfaces;
using MediatR;

namespace Application.UseCases.Alunos;

public class GetAllAlunosQueryHandler(IAlunosRepository repo) : IRequestHandler<GetAllAlunosQuery, IEnumerable<AlunoDto>>
{
    private readonly IAlunosRepository _repo = repo;

    public async Task<IEnumerable<AlunoDto>> Handle(GetAllAlunosQuery request, CancellationToken cancellationToken)
    {
        var alunos = await _repo.GetAll();

        List<AlunoDto> alunosDtos = [];

        foreach (var aluno in alunos)
        {
            alunosDtos.Add(AlunoDto.FromEntity(aluno));
        }

        return alunosDtos;
    }
}
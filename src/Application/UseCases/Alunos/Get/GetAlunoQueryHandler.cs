using Application.Dtos;
using Application.Interfaces;
using MediatR;

namespace Application.UseCases.Alunos;

public class GetAlunoQueryHandler(IAlunosRepository repo) : IRequestHandler<GetAlunoQuery, AlunoDto>
{
    private readonly IAlunosRepository _repo = repo;

    public async Task<AlunoDto> Handle(GetAlunoQuery request, CancellationToken cancellationToken)
    {
        var aluno = await _repo.GetById(request.Id) 
            ?? throw new Exception("Aluno não encontrado");
        
        var alunoDto = AlunoDto.FromEntity(aluno);

        return alunoDto;
    }
}
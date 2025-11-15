using Application.Common;
using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Alunos;

public class GetAlunoQueryHandler(IAlunosRepository repo) : IRequestHandler<GetAlunoQuery, Result<AlunoDto>>
{
    private readonly IAlunosRepository _repo = repo;

    public async Task<Result<AlunoDto>> Handle(GetAlunoQuery request, CancellationToken cancellationToken)
    {
        var aluno = await _repo.GetById(request.Id); 

        if (aluno == null)
            return Error.NotFound("Aluno não encontrado");

        var alunoDto = AlunoDto.FromEntity(aluno);

        return Result.Sucess(alunoDto);
    }
}
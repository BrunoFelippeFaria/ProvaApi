using Application.Common;
using Application.Dtos;
using MediatR;

namespace Application.UseCases.Alunos;

public record GetAllAlunosQuery : IRequest<Result<IEnumerable<AlunoDto>>>; 
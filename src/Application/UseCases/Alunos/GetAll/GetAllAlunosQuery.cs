using Application.Dtos;
using MediatR;

namespace Application.UseCases.Alunos;

public record GetAllAlunosQuery : IRequest<IEnumerable<AlunoDto>>; 
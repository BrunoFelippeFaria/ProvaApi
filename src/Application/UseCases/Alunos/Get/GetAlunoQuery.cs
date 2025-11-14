using Application.Dtos;
using MediatR;

namespace Application.UseCases.Alunos;

public record GetAlunoQuery(int Id) : IRequest<AlunoDto>;
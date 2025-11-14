using Domain.Entities;

namespace Application.Dtos;

public class AlunoDto
{
    public required int Id {get; set; }
    public required string Nome {get; set; }

    public static AlunoDto FromEntity(Aluno aluno)
    {
        return new AlunoDto
        {
            Id = aluno.Id,
            Nome = aluno.Nome
        };
    }
}
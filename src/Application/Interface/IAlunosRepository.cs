using Domain.Entities;

namespace Application.Interfaces;

public interface IAlunosRepository
{
    public Task<IEnumerable<Aluno>> GetAll();
}
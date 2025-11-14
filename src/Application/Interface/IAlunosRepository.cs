using Domain.Entities;

namespace Application.Interfaces;

public interface IAlunosRepository
{
    public Task<IEnumerable<Aluno>> GetAll();
    public Task<Aluno?> GetById(int Id);
}
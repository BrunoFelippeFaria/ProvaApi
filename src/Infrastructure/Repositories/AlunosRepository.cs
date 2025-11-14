using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AlunosRepository(AppDbContext context) : IAlunosRepository
{
    private readonly AppDbContext _context = context; 

    public async Task<IEnumerable<Aluno>> GetAll()
    {
        var alunos = await _context.Alunos.ToArrayAsync();
        return alunos;
    }
}
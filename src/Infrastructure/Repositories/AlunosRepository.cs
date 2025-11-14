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

    public async Task<Aluno?> GetById(int Id)
    {
        var aluno = await _context.Alunos
            .FirstOrDefaultAsync(a => a.Id == Id);
        
        return aluno;
    }

}
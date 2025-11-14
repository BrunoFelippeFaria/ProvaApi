using Application.Interfaces;
using Application.UseCases.Alunos;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureServices (this IServiceCollection services)
    {
        services.AddScoped<AppDbContext>();
        services.AddScoped<IAlunosRepository, AlunosRepository>();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(GetAllAlunosQuery).Assembly);
        });

        return services;
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities = Domain.Entities;

namespace Infra.Persistence.Seed;

/// <summary>
/// Classe que insere algumas informações iniciais ao criar o banco de dados
/// </summary>
/// <remarks>Utilizada para popular o banco inicial para testes</remarks>
static class SeedGenerator
{
    public static void GenerateSeedData(ModelBuilder builder)
    {
        builder.Entity<Entities.Task>().HasData(
            new Entities.Task
            {
                Id = 1,
                Description = "[Teste] - Comprar legumes",
                IsCompleted = true
            },
            new Entities.Task
            {
                Id = 2,
                Description = "[Teste] - Revisar óleo do carro",
                IsCompleted = false
            },
            new Entities.Task
            {
                Id = 3,
                Description = "[Teste] - Planejar atividades de férias",
                IsCompleted = false
            }
        );
    }
}
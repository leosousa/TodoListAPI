using Entities = Domain.Entities;

namespace Infra.Persistence.Seed;

/// <summary>
/// Classe que insere algumas informações iniciais ao criar o banco de dados
/// </summary>
/// <remarks>Utilizada para popular o banco inicial para testes</remarks>
static class ToDoDatabaseContextSeed
{
    public static async Task SeedSampleDataAsync(ToDoDatabaseContext context)
    {
        // Só executa esse método caso o banco esteja vazio
        if (context.Tasks.Any()) return;

        context.Tasks.AddRange(
            new Entities.Task { 
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

        await context.SaveChangesAsync();
    }
}
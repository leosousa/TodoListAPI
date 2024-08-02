using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Entities = Domain.Entities;

namespace Infra.Persistence;

/// <summary>
/// Classe que comunica-se com o banco de dados para operações de leitura e escrita
/// </summary>
public class ToDoDatabaseContext : DbContext
{
    public ToDoDatabaseContext(DbContextOptions<ToDoDatabaseContext> options) : base(options)
    {
    }

    public DbSet<Entities.Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Cada classe dentro da pasta Configurations tem suas definições de tabela.
        // Elas são carregadas de forma automática na chamada abaixo
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}

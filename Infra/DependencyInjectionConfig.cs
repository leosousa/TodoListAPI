using Domain.Interfaces;
using Infra.Persistence;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionConfig
{
    public static void AddInfraDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ToDoDatabaseContext>(db => db.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

        services.AddScoped<ITaskRepository, TaskRepository>();
    }
}

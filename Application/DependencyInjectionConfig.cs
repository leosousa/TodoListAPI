namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionConfig
{
    public static void AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
    }
}
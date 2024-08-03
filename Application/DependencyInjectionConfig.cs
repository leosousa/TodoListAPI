using Application.Base.Behaviors;
using FluentValidation;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionConfig
{
    public static void AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
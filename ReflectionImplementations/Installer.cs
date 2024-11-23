using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ReflectionImplementations;

public static class Installer
{
    public static void InstallReflectionImplementations(this IServiceCollection services)
    {
        services.AddSingleton<IFactory, IFactory>();

        var implementations = Assembly.GetExecutingAssembly().GetTypes()
            .Where(typeof(IImplementation).IsAssignableFrom)
            .Where(t => t.IsClass && !t.IsAbstract)
            .ToList();

        implementations.ForEach(x => services.AddScoped(x));
    }
}

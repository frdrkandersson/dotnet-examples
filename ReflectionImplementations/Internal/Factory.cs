using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ReflectionImplementations.Internal;

internal class Factory : IFactory
{
    public static readonly Dictionary<string, Type> _implementations = [];

    private readonly IServiceProvider _serviceProvider;

    public Factory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        ScanImplementations();
    }

    public IImplementation Create(string key)
    {
        if (!_implementations.TryGetValue(key, out var type))
        {
            throw new Exception($"{key} not registered");
        }

        var instance = _serviceProvider.GetRequiredService(type) as IImplementation;

        return instance ?? throw new Exception($"unable to instantiate {type}, make sure the type is registered in di-container");
    }

    private static void ScanImplementations()
    {
        var implementations = Assembly.GetExecutingAssembly().GetTypes()
           .Where(x => !x.IsAbstract && !x.IsInterface)
           .Where(x => typeof(IImplementation).IsAssignableFrom(x));

        foreach (var implementation in implementations)
        {
            var attribute = implementation.GetCustomAttribute<ImplementationAttribute>()
                ?? throw new Exception($"{implementation.FullName} is missing attribute");

            if (!_implementations.TryAdd(attribute.Key, implementation))
                throw new Exception($"unable to add {implementation.GetType()} to registry");
        }
    }
}
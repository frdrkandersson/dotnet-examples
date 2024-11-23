using Microsoft.Extensions.DependencyInjection;
using ReflectionImplementations;

var services = new ServiceCollection();

services.InstallReflectionImplementations();

var serviceProvider = services.BuildServiceProvider();

var factory = serviceProvider.GetRequiredService<IFactory>();

factory.Create("A").Execute();
factory.Create("B").Execute();

Console.ReadLine();
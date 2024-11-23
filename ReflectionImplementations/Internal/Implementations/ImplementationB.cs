namespace ReflectionImplementations.Internal.Implementations;

[Implementation("B")]
internal class ImplementationB : IImplementation
{
    public void Execute()
    {
        Console.WriteLine("Hello from B");
    }
}

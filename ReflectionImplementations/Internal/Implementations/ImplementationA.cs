namespace ReflectionImplementations.Internal.Implementations;

[Implementation("A")]
internal class ImplementationA : IImplementation
{
    public void Execute()
    {
        Console.WriteLine("Hello from A");
    }
}

namespace ReflectionImplementations.Internal;

[AttributeUsage(AttributeTargets.Class)]
internal class ImplementationAttribute(string key) : Attribute
{
    public string Key { get; private set; } = key;
}
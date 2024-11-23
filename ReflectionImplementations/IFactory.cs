namespace ReflectionImplementations;

public interface IFactory
{
    IImplementation Create(string key);
}

namespace Catharsium.Util.Interfaces;

public interface ITypesLoader
{
    IEnumerable<Type> Load<T>(string folder);
}
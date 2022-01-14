namespace Catharsium.Util.IO.Files.Interfaces;

public interface IJsonFileRepository<T>
{
    Task<List<T>> Get();
    Task<T> Get(string key);
    Task Add(T data, string key);
    Task Remove(string key);
}
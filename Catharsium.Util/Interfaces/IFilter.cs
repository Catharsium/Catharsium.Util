namespace Catharsium.Util.Interfaces;

public interface IFilter<in T>
{
    bool Includes(T item);
}
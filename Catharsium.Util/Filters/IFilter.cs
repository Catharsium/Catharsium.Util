namespace Catharsium.Util.Filters
{
    public interface IFilter<in T>
    {
        bool Includes(T item);
    }
}
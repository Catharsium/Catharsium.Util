namespace Catharsium.Util.Filters
{
    public interface IFilter
    {
        bool Includes<T>(T item);
    }
}
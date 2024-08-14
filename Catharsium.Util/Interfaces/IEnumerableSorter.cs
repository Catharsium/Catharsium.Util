namespace Catharsium.Util.Interfaces;

public interface IEnumerableSorter<T> where T : IComparable<T>
{
    IEnumerable<T> Sort(IEnumerable<T> items);
}
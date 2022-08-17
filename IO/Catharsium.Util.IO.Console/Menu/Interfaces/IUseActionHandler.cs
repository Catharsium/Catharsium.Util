using System.Threading.Tasks;

namespace Catharsium.Util.IO.Console.Menu.Interfaces;

public interface IUseActionHandler<T>
{
    Task Select(T item);
}
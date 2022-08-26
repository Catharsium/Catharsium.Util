using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Util.IO.Console.Menu.Interfaces;

public interface IGetActionHandler<T>
{
    Task<T> Select(IEnumerable<T> items);
}
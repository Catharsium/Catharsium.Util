using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catharsium.Util.IO.Interfaces
{
    public interface IJsonFileRepository<T>
    {
        Task<IEnumerable<T>> Load(string fileName);
        Task<IEnumerable<T>> LoadAll();
        Task Store(IEnumerable<T> data, string fileName);
    }
}
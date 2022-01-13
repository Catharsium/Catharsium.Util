using System.Threading.Tasks;

namespace Catharsium.Util.IO.Console.Interfaces
{
    public interface IActionHandler
    {
        string DisplayName { get; }
        Task<T> Run<T>();
    }
}
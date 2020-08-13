using System.Threading.Tasks;

namespace Catharsium.Util.IO.Console.Interfaces
{
    public interface IActionHandler
    {
        string FriendlyName { get; }

        Task Run();
    }
}
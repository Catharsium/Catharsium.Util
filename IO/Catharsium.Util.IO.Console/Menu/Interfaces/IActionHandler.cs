using System.Threading.Tasks;

namespace Catharsium.Util.IO.Console.Menu.Interfaces;

public interface IActionHandler
{
    string MenuName { get; }

    Task Run();
}
using System.Threading.Tasks;
namespace Catharsium.Util.IO.Console.ActionHandlers.Interfaces;

public interface IActionHandler
{
    string MenuName { get; }

    Task Run();
}
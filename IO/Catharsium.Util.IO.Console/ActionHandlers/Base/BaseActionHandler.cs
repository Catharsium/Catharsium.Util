using Catharsium.Util.IO.Console.ActionHandlers.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
using System.Threading.Tasks;
namespace Catharsium.Util.IO.Console.ActionHandlers.Base;

public abstract class BaseActionHandler : IActionHandler
{
    protected readonly IConsole console;

    public string MenuName { get; }


    public BaseActionHandler(IConsole console, string menuName)
    {
        this.console = console;
        this.MenuName = menuName;
    }


    public abstract Task Run();


    public override string ToString()
    {
        return this.MenuName;
    }
}
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Menu.Interfaces;
using System.Threading.Tasks;

namespace Catharsium.Util.IO.Console.Menu.Base;

public abstract class BaseActionHandler(IConsole console, string menuName) : IActionHandler
{
    protected readonly IConsole Console = console;

    public string MenuName { get; } = menuName;

    public abstract Task Run();


    public override string ToString() {
        return this.MenuName;
    }
}
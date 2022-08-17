using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Menu.Interfaces;
using System.Threading.Tasks;

namespace Catharsium.Util.IO.Console.Menu.Base;

public abstract class BaseActionHandler : IActionHandler
{
    protected readonly IConsole Console;

    public string MenuName { get; }


    public BaseActionHandler(IConsole console, string menuName) {
        this.Console = console;
        this.MenuName = menuName;
    }


    public abstract Task Run();


    public override string ToString() {
        return this.MenuName;
    }
}
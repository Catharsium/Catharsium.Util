using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Menu.Base;
using Catharsium.Util.IO.Console.Menu.Interfaces;
using System.Collections.Generic;

namespace Catharsium.Util.IO.Console.Menu.Implementation;

public class MainMenuActionHandler : BaseMenuActionHandler<IActionHandler>, IMainMenuActionHandler
{
    public MainMenuActionHandler(IEnumerable<IMenuActionHandler> actionHandlers, IConsole console)
        : base(actionHandlers, console, "Main") {
    }
}
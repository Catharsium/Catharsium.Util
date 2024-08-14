using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Menu.Base;
using Catharsium.Util.IO.Console.Menu.Interfaces;
using System.Collections.Generic;

namespace Catharsium.Util.IO.Console.Menu.Implementation;

public class MainMenuActionHandler(IEnumerable<IMenuActionHandler> actionHandlers, IConsole console) :
    BaseMenuActionHandler<IActionHandler>(actionHandlers, console, "Main"), IMainMenuActionHandler
{
}
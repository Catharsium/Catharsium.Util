using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.ActionHandlers.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
namespace Catharsium.Util.IO.Console.ActionHandlers.Implementation;

public class MainMenuActionHandler : BaseMenuActionHandler<IActionHandler>, IMainMenuActionHandler
{
    public MainMenuActionHandler(IEnumerable<IMenuActionHandler> actionHandlers, IConsole console) : base(actionHandlers, console, "Main")
    {
    }
}
using Catharsium.Util.IO.Console.ActionHandlers.Interfaces;
using Catharsium.Util.IO.Console.ActionHandlers.Interfaces.Internal;
using Catharsium.Util.IO.Console.Interfaces;
namespace Catharsium.Util.IO.Console.ActionHandlers.Implementation;

public class MainMenuActionHandler : MenuActionHandler<IActionHandler>, IMainMenuActionHandler
{
    public override string MenuName => "Main";


    public MainMenuActionHandler(IEnumerable<IMenuActionHandler> actionHandlers, IConsole console) : base(actionHandlers, console)
    {
    }
}
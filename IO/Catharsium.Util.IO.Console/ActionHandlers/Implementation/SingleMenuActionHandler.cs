using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.ActionHandlers.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
using System.Collections.Generic;

namespace Catharsium.Util.IO.Console.ActionHandlers.Implementation;

public class SingleMenuActionHandler : BaseMenuActionHandler<IActionHandler>, ISingleMenuActionHandler
{
    public SingleMenuActionHandler(IEnumerable<IActionHandler> actionHandlers, IConsole console) : base(actionHandlers, console, "Main")
    { }
}
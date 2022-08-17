using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Menu.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Util.IO.Console.Menu.Base;

public abstract class BaseMenuActionHandler<T> : BaseActionHandler, IMenuActionHandler where T : IActionHandler
{
    protected readonly IEnumerable<T> ActionHandlers;


    public BaseMenuActionHandler(IEnumerable<T> actionHandlers, IConsole console, string menuName) : base(console, menuName) {
        this.ActionHandlers = actionHandlers.ToList();
    }


    public override async Task Run() {
        while (true) {
            this.Console.WriteLine("Please select an action:");
            var index = 1;
            foreach (var actionHandler in this.ActionHandlers) {
                this.Console.WriteLine($"[{index++}] {actionHandler.MenuName}");
            }

            var selectedIndex = this.Console.AskForInt();
            if (!selectedIndex.HasValue || selectedIndex <= 0 || selectedIndex > this.ActionHandlers.Count()) {
                break;
            }

            this.Console.WriteLine();
            await this.ActionHandlers.ElementAt(selectedIndex.Value - 1).Run();
            this.Console.WriteLine();
        }
    }
}
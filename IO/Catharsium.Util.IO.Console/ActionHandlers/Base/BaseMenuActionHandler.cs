using Catharsium.Util.IO.Console.ActionHandlers.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
namespace Catharsium.Util.IO.Console.ActionHandlers.Base;

public abstract class BaseMenuActionHandler<T> : BaseActionHandler, IMenuActionHandler where T : IActionHandler
{
    private readonly IEnumerable<T> actionHandlers;


    public BaseMenuActionHandler(IEnumerable<T> actionHandlers, IConsole console, string menuName) : base(console, menuName)
    {
        this.actionHandlers = actionHandlers.ToList();
    }


    public override async Task Run()
    {
        while (true) {
            this.console.WriteLine("Please select an action:");
            var index = 1;
            foreach (var actionHandler in this.actionHandlers) {
                this.console.WriteLine($"[{index++}] {actionHandler.MenuName}");
            }

            var selectedIndex = this.console.AskForInt();
            if (!selectedIndex.HasValue || selectedIndex <= 0 || selectedIndex > this.actionHandlers.Count()) {
                break;
            }

            this.console.WriteLine();
            await this.actionHandlers.ElementAt(selectedIndex.Value - 1).Run();
            this.console.WriteLine();
        }
    }
}
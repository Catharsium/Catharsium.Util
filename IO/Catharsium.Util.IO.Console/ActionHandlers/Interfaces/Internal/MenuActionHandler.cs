using Catharsium.Util.IO.Console.Interfaces;
namespace Catharsium.Util.IO.Console.ActionHandlers.Interfaces.Internal;

public abstract class MenuActionHandler<T> : IMenuActionHandler where T : IActionHandler
{
    private readonly IEnumerable<T> actionHandlers;
    private readonly IConsole console;

    public abstract string MenuName { get; }


    public MenuActionHandler(IEnumerable<T> actionHandlers, IConsole console)
    {
        this.actionHandlers = actionHandlers.ToList();
        this.console = console;
    }


    public async Task Run()
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
using Catharsium.Util.IO.Console.Interfaces;
namespace Catharsium.Util.IO.Console.ActionHandlers;

public class ActionHandlerRetriever : IActionHandlerRetriever
{
    private readonly IEnumerable<IActionHandler> actionHandlers;


    public ActionHandlerRetriever(IEnumerable<IActionHandler> actionHandlers)
    {
        this.actionHandlers = actionHandlers;
    }


    public T Get<T>()
    {
        var result = (T)this.actionHandlers.FirstOrDefault(a => a.GetType() == typeof(T));
        return result == null
            ? throw new ArgumentException($"No action handler of type {typeof(T)} was found")
            : result;
    }
}
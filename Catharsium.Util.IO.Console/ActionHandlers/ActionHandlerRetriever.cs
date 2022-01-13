using Catharsium.Util.IO.Console.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.IO.Console.ActionHandlers
{
    public class ActionHandlerRetriever : IActionHandlerRetriever
    {
        private readonly IEnumerable<IActionHandler> actionHandlers;


        public ActionHandlerRetriever(IEnumerable<IActionHandler> actionHandlers)
        {
            this.actionHandlers = actionHandlers;
        }


        public T Get<T>()
        {
            return (T)this.actionHandlers.FirstOrDefault(a => a.GetType() == typeof(T));
        }
    }
}
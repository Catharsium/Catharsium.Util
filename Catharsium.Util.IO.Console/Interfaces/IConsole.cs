using System;
using System.Collections.Generic;

namespace Catharsium.Util.IO.Console.Interfaces
{
    public interface IConsole : IConsoleWrapper
    {
        string AskForText(string message = null);
        int? AskForInt(string message = null);
        T AskForItem<T>(IEnumerable<T> items, string message = null);
        string AskForItem(IEnumerable<string> items, string message = null);
        DateTime? AskForDate(string message = null);
    }
}
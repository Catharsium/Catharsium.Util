using System;

namespace Catharsium.Util.IO.Console.Interfaces
{
    public interface IConsole : IConsoleWrapper
    {
        string AskForText(string message = null);
        int? AskForInt(string message = null);
        DateTime? AskForDate(string message = null);
    }
}
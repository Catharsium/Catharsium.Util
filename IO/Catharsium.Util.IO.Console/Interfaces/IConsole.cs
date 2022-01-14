namespace Catharsium.Util.IO.Console.Interfaces;

public interface IConsole : IConsoleWrapper
{
    string AskForText(string message = null);
    int? AskForInt(string message = null);
    T AskForItem<T>(IEnumerable<T> items, string message = null);
    string AskForItem(IEnumerable<string> items, string message = null);
    DateTime? AskForDate(string message = null);
    DateTime AskForDate(string message, DateTime defaultValue);
    void FillBlock(int textLength, int blockLength = 8, char filler = ' ');
}
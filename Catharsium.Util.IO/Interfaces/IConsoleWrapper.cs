using System;

namespace Catharsium.Util.IO.Interfaces
{
    public interface IConsoleWrapper
    {
        ConsoleColor ForegroundColor { get; set; }
        ConsoleColor BackgroundColor { get; set; }
        void ResetColor();

        int Read();
        ConsoleKeyInfo ReadKey();
        string ReadLine();

        void Write(string text);
        void WriteLine(string text);
    }
}
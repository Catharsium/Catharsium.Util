using System;
using System.IO;

namespace Catharsium.Util.IO.Console.Interfaces
{
    public interface IConsoleWrapper
    {
        ConsoleColor BackgroundColor { get; set; }
        int BufferHeight { get; set; }
        int BufferWidth { get; set; }
        bool CapsLock { get; }
        int CursorLeft { get; set; }
        int CursorSize { get; set; }
        int CursorTop { get; set; }
        bool CursorVisible { get; set; }
        ConsoleColor ForegroundColor { get; set; }
        TextReader In { get; }
        TextWriter Out { get; }
        string Title { get; set; }
        void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop);
        void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor);
        int Read();
        ConsoleKeyInfo ReadKey();
        string ReadLine();
        void ResetColor();
        void SetBufferSize(int width, int height);
        void SetCursorPosition(int left, int top);
        void Write(string text);
        void WriteLine(string text = null);
        void WriteLine(string text, ConsoleColor color);
    }
}
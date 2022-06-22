using System;
using System.IO;

namespace Catharsium.Util.IO.Console.Interfaces;

public interface IConsoleWrapper
{
    int BufferHeight { get; set; }
    int BufferWidth { get; set; }
    bool CapsLock { get; }
    int CursorLeft { get; set; }
    int CursorSize { get; set; }
    int CursorTop { get; set; }
    bool CursorVisible { get; set; }

    ConsoleColor BackgroundColor { get; set; }
    ConsoleColor ForegroundColor { get; set; }
    void ResetColor();

    TextReader In { get; }
    TextWriter Out { get; }
    string Title { get; set; }
    void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop);
    void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor);

    void Beep(int frequency, int duration);

    int Read();
    ConsoleKeyInfo ReadKey();
    string ReadLine();


    void Write(string text);
    void WriteLine(string text = null);
    void WriteLine(string text, ConsoleColor color);

    void SetBufferSize(int width, int height);
    void SetCursorPosition(int left, int top);

    int WindowWidth { get; set; }
    int LargestWindowWidth { get; }
    int WindowHeight { get; set; }
    int LargestWindowHeight { get; }
    int WindowLeft { get; set; }
    int WindowTop { get; set; }
    void SetWindowPosition(int left, int top);
    void SetWindowSize(int width, int height);
}
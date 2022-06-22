using System;
using System.Collections.Generic;

namespace Catharsium.Util.IO.Console.Interfaces;

public interface IConsole : IConsoleWrapper
{
    string AskForText(string message = null);
    void FillBlock(int textLength, int blockLength = 8, char filler = ' ');
    T AskForItem<T>(IEnumerable<T> items, string message = null);

    int? AskForInt(string message = null);
    int AskForInt(int defaultValue, string message = null);

    decimal? AskForDecimal(string message = null);
    decimal AskForDecimal(decimal defaultValue, string message = null);

    T? AskForEnum<T>(string message = null) where T : struct, IConvertible;
    T AskForEnum<T>(T defaultValue, string message = null) where T : struct, IConvertible;

    DateTime? AskForDate(string message = null);
    DateTime AskForDate(DateTime defaultValue, string message = null);
}
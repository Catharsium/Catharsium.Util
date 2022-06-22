using Catharsium.Util.Enums;
using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace Catharsium.Util.IO.Console.Wrappers;

public class ExtendedConsole : SystemConsoleWrapper, IConsole
{
    private readonly IConsoleWrapper console;


    public ExtendedConsole(IConsoleWrapper console)
    {
        this.console = console;
    }


    public string AskForText(string message = null)
    {
        if (message != null) {
            this.console.WriteLine(message);
        }

        return this.console.ReadLine();
    }


    public void FillBlock(int textLength, int blockLength = 8, char filler = ' ')
    {
        for (var i = textLength; i < blockLength; i++) {
            this.console.Write(filler.ToString());
        }
    }


    public T AskForItem<T>(IEnumerable<T> items, string message = null)
    {
        var itemList = items.ToList();
        for (var i = 1; i <= itemList.Count; i++) {
            this.console.WriteLine($"[{i}] {itemList[i - 1]}");
        }

        var selectedIndex = this.AskForInt(message);
        return selectedIndex.HasValue && selectedIndex.Value > 0 && selectedIndex.Value <= itemList.Count
            ? itemList[selectedIndex.Value - 1]
            : default;
    }

    #region AskForInt

    public int? AskForInt(string message = null)
    {
        if (message != null) {
            this.console.WriteLine(message);
        }

        return int.TryParse(this.console.ReadLine(), out var result)
            ? result
            : null;
    }


    public int AskForInt(int defaultValue, string message = null)
    {
        var result = this.AskForInt(message);
        return result ?? defaultValue
;
    }

    #endregion

    #region AskForDecimal

    public decimal? AskForDecimal(string message = null)
    {
        if (message != null) {
            this.console.WriteLine(message);
        }

        return decimal.TryParse(this.console.ReadLine(), out var result)
            ? result
            : null;
    }


    public decimal AskForDecimal(decimal defaultValue, string message = null)
    {
        var result = this.AskForDecimal(message);
        return result ?? defaultValue
;
    }

    #endregion

    #region AskForEnum

    public T? AskForEnum<T>(string message = null) where T : struct, IConvertible
    {
        var itemList = EnumValuesHelper.GetValues<T>();
        for (var i = 1; i <= itemList.Count(); i++) {
            this.console.WriteLine($"[{i}] {itemList.ElementAt(i - 1)}");
        }

        var selectedIndex = this.AskForInt(message);
        return selectedIndex.HasValue && selectedIndex.Value > 0 && selectedIndex.Value <= itemList.Count()
            ? itemList.ElementAt(selectedIndex.Value - 1)
            : null;
    }


    public T AskForEnum<T>(T defaultValue, string message = null) where T : struct, IConvertible
    {
        var result = this.AskForEnum<T>(message);
        return result ?? defaultValue;
    }

    #endregion

    #region AskForDate

    public DateTime? AskForDate(string message = null)
    {
        this.WriteMessage(message);
        var input = this.console.ReadLine();
        return ParseDate(input);
    }


    public DateTime AskForDate(DateTime defaultValue, string message)
    {
        this.WriteMessage(message);
        var input = this.console.ReadLine();

        if (int.TryParse(input, out var inputAsNumber)) {
            return defaultValue.AddDays(inputAsNumber);
        }

        var result = ParseDate(input);
        return !result.HasValue
            ? defaultValue
            : (DateTime)result;
    }


    private static DateTime? ParseDate(string date)
    {
        date = date.Replace("-", "").Replace(":", "").Replace(" ", "");

        var datePattern = "^(\\d{4})(\\d{2})(\\d{2})(\\d*)$";
        var matchDate = new Regex(datePattern).Match(date);
        if (!matchDate.Success) {
            return null;
        }

        var year = int.Parse(matchDate.Groups[1].Value);
        var month = int.Parse(matchDate.Groups[2].Value);
        var day = int.Parse(matchDate.Groups[3].Value);

        var timePattern = "^(\\d{2})(\\d{2})(\\d*)$";
        var matchTime = new Regex(timePattern).Match(matchDate.Groups[4].Value);
        if (!matchTime.Success) {
            return new DateTime(year, month, day);
        }

        var hour = int.Parse(matchTime.Groups[1].Value);
        var minute = int.Parse(matchTime.Groups[2].Value);
        if (!int.TryParse(matchTime.Groups[3].Value, out var second)) {
            second = 0;
        }

        return new DateTime(year, month, day, hour, minute, second);
    }


    private void WriteMessage(string message)
    {
        if (message != null) {
            this.console.WriteLine(message);
        }
    }

    #endregion
}
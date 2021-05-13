using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Catharsium.Util.IO.Console.Wrappers
{
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


        public int? AskForInt(string message = null)
        {
            if (message != null) {
                this.console.WriteLine(message);
            }

            return int.TryParse(this.console.ReadLine(), out var result)
                ? result
                : (int?)null;
        }


        public T AskForItem<T>(IEnumerable<T> items, string message = null)
        {
            var itemList = items.ToList();
            for (var i = 1 ; i <= itemList.Count ; i++) {
                this.console.WriteLine($"[{i}] {itemList[i - 1]}");
            }

            var selectedIndex = this.AskForInt(message);
            if (selectedIndex.HasValue && selectedIndex.Value > 0 && selectedIndex.Value <= itemList.Count) {
                return itemList[selectedIndex.Value - 1];
            }

            return default;
        }


        public string AskForItem(IEnumerable<string> items, string message = null)
        {
            return this.AskForItem<string>(items, message);
        }


        public DateTime? AskForDate(string message)
        {
            if (message != null) {
                this.console.WriteLine(message);
            }

            var dateInput = this.console.ReadLine();
            dateInput = dateInput.Replace("-", "").Replace(":", "").Replace(" ", "");

            var datePattern = "^(\\d{4})(\\d{2})(\\d{2})(\\d*)$";
            var matchDate = new Regex(datePattern).Match(dateInput);
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


        public DateTime AskForDate(string message, DateTime defaultValue)
        {
            var result = this.AskForDate(message);
            return !result.HasValue
                ? defaultValue
                : (DateTime)result;
        }


        public void FillSection(int textLength, int sectionLength = 8, char filler = ' ')
        {
            for (var i = textLength ; i < sectionLength ; i++) {
                this.console.Write(filler.ToString());
            }
        }
    }
}
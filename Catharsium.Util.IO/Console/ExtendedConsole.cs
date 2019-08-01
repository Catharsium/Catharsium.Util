using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.IO.Wrappers;
using System;
using System.Text.RegularExpressions;

namespace Catharsium.Util.IO.Console
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
                ? result :
                (int?)null;
        }


        public DateTime? AskForDate(string message = null)
        {
            if (message != null) {
                this.console.WriteLine(message);
            }

            var dateInput = this.console.ReadLine();
            dateInput = dateInput.Replace("-", "").Replace(":", "").Replace(" ", "");

            var datePattern = "^(\\d{4})(\\d{2})(\\d{2})(\\d*)$";
            var matchDate = new Regex(datePattern).Match(dateInput);
            if (matchDate.Success) {
                var year = int.Parse(matchDate.Groups[1].Value);
                var month = int.Parse(matchDate.Groups[2].Value);
                var day = int.Parse(matchDate.Groups[3].Value);

                var timePattern = "^(\\d{2})(\\d{2})(\\d*)$";
                var matchTime = new Regex(timePattern).Match(matchDate.Groups[4].Value);
                if (matchTime.Success) {
                    var hour = int.Parse(matchTime.Groups[1].Value);
                    var minute = int.Parse(matchTime.Groups[2].Value);
                    if (!int.TryParse(matchTime.Groups[3].Value, out var second)) {
                        second = 0;
                    }

                    return new DateTime(year, month, day, hour, minute, second);
                }

                return new DateTime(year, month, day);
            }

            return null;
        }
    }
}
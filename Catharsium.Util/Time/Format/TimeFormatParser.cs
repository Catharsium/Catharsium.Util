using Catharsium.Util.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace Catharsium.Util.Time.Format
{
    public class TimeFormatParser : ITimeFormatParser
    {
        public TimePeriod Parse(string format)
        {
            var result = new TimePeriod();
            var pattern = "^(\\d+[a-zA-Z]\\s*)*$";
            var match = Regex.Match(format, pattern);

            if (match.Success && match.Groups.Count == 2) {
                for (var i = 0; i < match.Groups[1].Captures.Count; i++) {
                    var part = match.Groups[1].Captures[i].Value.Trim();
                    result += this.Parse(int.Parse(part.Substring(0, part.Length - 1)), part.Substring(part.Length - 1));
                }
            }

            return result;
        }


        public TimePeriod Parse(int quantity, string type)
        {
            switch (type.ToLower()) {
                case "y":
                    return new TimePeriod { Years = quantity };
                case "w":
                    return new TimePeriod { Weeks = quantity };
                case "d":
                    return new TimePeriod { Days = quantity };
                case "h":
                    return new TimePeriod { Hours = quantity };
                case "m":
                    return new TimePeriod { Minutes = quantity };
                case "s":
                    return new TimePeriod { Seconds = quantity };
                default:
                    return new TimePeriod();
            }
        }
    }
}
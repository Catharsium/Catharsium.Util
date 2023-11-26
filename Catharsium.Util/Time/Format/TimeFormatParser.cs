using Catharsium.Util.Interfaces;
using System.Text.RegularExpressions;

namespace Catharsium.Util.Time.Format;

public class TimeFormatParser : ITimeFormatParser
{
    public TimePeriod Parse(string format) {
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


    public TimePeriod Parse(int quantity, string type) {
        return type.ToLower() switch {
            "y" => new TimePeriod { Years = quantity },
            "w" => new TimePeriod { Weeks = quantity },
            "d" => new TimePeriod { Days = quantity },
            "h" => new TimePeriod { Hours = quantity },
            "m" => new TimePeriod { Minutes = quantity },
            "s" => new TimePeriod { Seconds = quantity },
            _ => new TimePeriod(),
        };
    }
}
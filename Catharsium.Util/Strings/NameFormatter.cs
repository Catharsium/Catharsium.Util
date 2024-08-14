using Catharsium.Util.Interfaces;

namespace Catharsium.Util.Strings;

public class NameFormatter : INameFormatter
{
    public string Format(string format, string firstName, string lastName) {
        return this.Format(format, null, firstName, null, lastName);
    }


    public string Format(string format, string firstName, string infix, string lastName) {
        return this.Format(format, null, firstName, infix, lastName);
    }


    public string Format(string format, string prefix, string firstName, string infix, string lastName) {
        var result = format
            .Replace("PP", "{0}").Replace("Pp", "{1}").Replace("pp", "{2}").Replace("P", "{3}").Replace("p", "{4}")
            .Replace("FF", "{5}").Replace("Ff", "{6}").Replace("ff", "{7}").Replace("F", "{8}").Replace("f", "{9}")
            .Replace("II", "{10}").Replace("Ii", "{11}").Replace("ii", "{12}").Replace("I", "{13}").Replace("i", "{14}")
            .Replace("LL", "{15}").Replace("Ll", "{16}").Replace("ll", "{17}").Replace("L", "{18}").Replace("l", "{19}");

        if(!string.IsNullOrEmpty(prefix)) {
            result = result
                .Replace("{0}", prefix.ToUpper())
                .Replace("{1}", prefix.Capitalize())
                .Replace("{2}", prefix.ToLower())
                .Replace("{3}", prefix[..1].ToUpper())
                .Replace("{4}", prefix[..1].ToLower());
        }
        if(!string.IsNullOrEmpty(firstName)) {
            result = result
                .Replace("{5}", firstName.ToUpper())
                .Replace("{6}", firstName.Capitalize())
                .Replace("{7}", firstName.ToLower())
                .Replace("{8}", firstName[..1].ToUpper())
                .Replace("{9}", firstName[..1].ToLower());
        }
        if(!string.IsNullOrEmpty(infix)) {
            result = result
                .Replace("{10}", infix.ToUpper())
                .Replace("{11}", infix.Capitalize())
                .Replace("{12}", infix.ToLower())
                .Replace("{13}", infix[..1].ToUpper())
                .Replace("{14}", infix[..1].ToLower());
        }
        if(!string.IsNullOrEmpty(lastName)) {
            result = result
                .Replace("{15}", lastName.ToUpper())
                .Replace("{16}", lastName.Capitalize())
                .Replace("{17}", lastName.ToLower())
                .Replace("{18}", lastName[..1].ToUpper())
                .Replace("{19}", lastName[..1].ToLower());
        }

        for(var i = 0; i < 20; i++) {
            result = result.Replace("{" + i + "}", "");
        }
        while(result.Contains("  ")) {
            result = result.Replace("  ", " ");
        }

        return result.Trim();
    }
}
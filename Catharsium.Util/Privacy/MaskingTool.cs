using System.Text.RegularExpressions;

namespace Catharsium.Util.Privacy
{
    public class MaskingTool : IMaskingTool
    {
        public string MaskEmail(string email)
        {
            var pattern = @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)";
            return Regex.Replace(email, pattern, m => new string('*', m.Length));
        }


        public string MaskPhoneNumber(string phoneNumber)
        {
            if (phoneNumber == null) {
                return null;
            }

            var pattern = @"(?<=(06[\d]{2}|00\d{5}|\+\d{5}))[\d]+(?=[\d]{2})";
            return Regex.Replace(phoneNumber, pattern, m => new string('*', m.Length));
        }
    }
}
using System;
using System.Globalization;

namespace Catharsium.Util.Time.Extensions
{
    public static class DateTimeExtensions
    {
        public static int GetWeekOfYear(this DateTime date)
        {
            var cultureInfo = new CultureInfo("nl-NL");
            var calendar = cultureInfo.Calendar;
            var calendarWeekRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            return calendar.GetWeekOfYear(date, calendarWeekRule, firstDayOfWeek);
        }
    }
}
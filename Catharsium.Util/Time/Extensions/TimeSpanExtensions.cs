using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Time.Extensions
{
    public static class TimeSpanExtensions
    {
        public static TimeSpan Sum(this IEnumerable<TimeSpan> source)
        {
            return source.Aggregate(TimeSpan.Zero, (t1, t2) => t1 + t2);
        }


        public static TimeSpan Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> selector)
        {
            return source.Select(selector).Sum();
        }
    }
}
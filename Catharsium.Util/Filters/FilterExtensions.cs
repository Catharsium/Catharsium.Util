using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Filters
{
    public static class FilterExtensions
    {
        public static IEnumerable<TItem> Include<TFilter, TItem>(this IEnumerable<TItem> items, TFilter filter) where TFilter : IFilter
        {
            return items.Where(filter.Includes);
        }


        public static IEnumerable<TItem> Exclude<TFilter, TItem>(this IEnumerable<TItem> items, TFilter filter) where TFilter : IFilter
        {
            return items.Where(t => !filter.Includes(t));
        }
    }
}
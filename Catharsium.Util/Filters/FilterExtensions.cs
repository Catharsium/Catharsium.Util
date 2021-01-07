using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Filters
{
    public static class FilterExtensions
    {
        public static IEnumerable<TItem> Include<TFilter, TItem>(this IEnumerable<TItem> items, params TFilter[] filters) where TFilter : IFilter<TItem>
        {
            var result = items;
            foreach (var filter in filters) {
                result = result.Where(filter.Includes);
            }

            return result;
        }


        public static IEnumerable<TItem> Exclude<TFilter, TItem>(this IEnumerable<TItem> items, params TFilter[] filters) where TFilter : IFilter<TItem>
        {
            var result = items;
            foreach (var filter in filters) {
                result = result.Where(t => !filter.Includes(t));
            }

            return result;
        }
    }
}
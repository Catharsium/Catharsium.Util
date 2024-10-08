﻿using Catharsium.Util.Interfaces;

namespace Catharsium.Util.Filters;

public static class FilterExtensions
{
    public static IEnumerable<TItem> Include<TFilter, TItem>(this IEnumerable<TItem> items, List<TFilter> filters) where TFilter : IFilter<TItem> {
        return items.Include(filters.ToArray());
    }


    public static IEnumerable<TItem> Include<TFilter, TItem>(this IEnumerable<TItem> items, params TFilter[] filters) where TFilter : IFilter<TItem> {
        var result = items;
        foreach(var filter in filters) {
            result = result.Where(filter.Includes);
        }

        return result;
    }

    public static IEnumerable<TItem> Exclude<TFilter, TItem>(this IEnumerable<TItem> items, List<TFilter> filters) where TFilter : IFilter<TItem> {
        return items.Exclude(filters.ToArray());
    }


    public static IEnumerable<TItem> Exclude<TFilter, TItem>(this IEnumerable<TItem> items, params TFilter[] filters) where TFilter : IFilter<TItem> {
        var result = items;
        foreach(var filter in filters) {
            result = result.Where(t => !filter.Includes(t));
        }

        return result;
    }
}
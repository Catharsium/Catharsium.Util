using System;
using System.Collections.Generic;

namespace Catharsium.Util.Comparing.Sorting;

public static class QuickSortExtensions
{
    public static IEnumerable<T> QuickSort<T>(this IEnumerable<T> items, IComparer<T> comparer) where T : IComparable<T> {
        return new QuickSorter<T>(comparer).Sort(items);
    }
}
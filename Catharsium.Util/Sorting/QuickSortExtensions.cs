using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Sorting
{
    public static class QuickSortExtensions
    {
        public static IEnumerable<T> QuickSort<T>(this IEnumerable<T> items, IComparer<T> comparer) where T : IComparable<T>
        {
            var itemsList = items.ToList();
            var result = new List<T>();

            if (!itemsList.Any()) {
                return result;
            }

            var pivot = itemsList.FirstOrDefault();
            itemsList.RemoveAt(0);
            var smaller = itemsList.Where(i => i.CompareTo(pivot) < 0);
            var equal = itemsList.Where(i => i.CompareTo(pivot) == 0);
            var greater = itemsList.Where(i => i.CompareTo(pivot) > 0);
            result.AddRange(smaller.QuickSort(comparer));
            result.Add(pivot);
            result.AddRange(equal);
            result.AddRange(greater.QuickSort(comparer));

            return result;
        }
    }
}
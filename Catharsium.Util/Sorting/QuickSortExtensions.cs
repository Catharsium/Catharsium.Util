using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Sorting
{
    public static class QuickSortExtensions
    {
        public static IEnumerable<decimal> QuickSort(this IEnumerable<decimal> items) //where T : IComparable<T>
        {
            var itemsList = items.ToList();
            var result = new List<decimal>();

            if (!itemsList.Any()) {
                return result;
            }

            var pivot = itemsList.FirstOrDefault();
            itemsList.RemoveAt(0);
            var smaller = itemsList.Where(i => i < pivot);
            var equal = itemsList.Where(i => i == pivot);
            var greater = itemsList.Where(i => i > pivot);
            result.AddRange(smaller.QuickSort());
            result.Add(pivot);
            result.AddRange(equal);
            result.AddRange(greater.QuickSort());

            return result;
        }
    }
}
using Catharsium.Util.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Comparing.Sorting;

public class QuickSorter<T> : IEnumerableSorter<T> where T : IComparable<T>
{
    private readonly IComparer<T> comparer;


    public QuickSorter(IComparer<T> comparer) {
        this.comparer = comparer;
    }


    public IEnumerable<T> Sort(IEnumerable<T> items) {
        var itemsList = items.ToList();
        var result = new List<T>();
        var pivotIndex = this.FindPivotIndex(itemsList);

        if (!itemsList.Any() || pivotIndex < 0) {
            return result;
        }

        var pivot = itemsList[pivotIndex];
        itemsList.RemoveAt(pivotIndex);
        var smaller = itemsList.Where(i => this.comparer.Compare(i, pivot) < 0);
        var equal = itemsList.Where(i => this.comparer.Compare(i, pivot) == 0);
        var greater = itemsList.Where(i => this.comparer.Compare(i, pivot) > 0);
        result.AddRange(smaller.QuickSort(this.comparer));
        result.Add(pivot);
        result.AddRange(equal);
        result.AddRange(greater.QuickSort(this.comparer));

        return result;
    }


    public int FindPivotIndex(IEnumerable<T> items) {
        var list = items.ToList();
        var lastIndex = list.Count - 1;

        switch (list.Count) {
            case 0:
                break;
            case 1:
                return 0;
            case 2:
                if (list.Count == 2) {
                    if (this.comparer.Compare(list[0], list[lastIndex]) <= 0) {
                        return 0;
                    }
                }

                break;
            default:
                var middleIndex = (int)Math.Round((double)list.Count / 2);
                if (this.comparer.Compare(list[0], list[middleIndex]) <= 0 && this.comparer.Compare(list[0], list[lastIndex]) >= 0 ||
                    this.comparer.Compare(list[0], list[middleIndex]) >= 0 && this.comparer.Compare(list[0], list[lastIndex]) <= 0) {
                    return 0;
                }
                if (this.comparer.Compare(list[middleIndex], list[0]) <= 0 && this.comparer.Compare(list[middleIndex], list[lastIndex]) >= 0 ||
                    this.comparer.Compare(list[middleIndex], list[0]) >= 0 && this.comparer.Compare(list[middleIndex], list[lastIndex]) <= 0) {
                    return middleIndex;
                }

                break;
        }

        return lastIndex;
    }
}
using Catharsium.Util.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Filters;

public class OrFilter<T> : IFilter<T>
{
    public List<IFilter<T>> Filters { get; set; }


    public bool Includes(T @event) {
        return this.Filters.Any(f => f.Includes(@event));
    }
}
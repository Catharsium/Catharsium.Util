using System;
using System.Collections.Generic;

namespace Catharsium.Util.Testing._Configuration
{
    public class SupportedDependencies
    {
        public static IEnumerable<Type> Types =>
            new List<Type> {
                typeof(Guid)
            };
    }
}
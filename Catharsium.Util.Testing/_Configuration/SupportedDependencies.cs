using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Catharsium.Util.Testing._Configuration
{
    public class SupportedDependencies
    {
        public static IEnumerable<Type> Types =>
            new List<Type> {
                typeof(Guid),
                typeof(DbContext)
            };
    }
}
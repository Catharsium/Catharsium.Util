﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Catharsium.Util.Testing.Configuration
{
    public class SupportedDependencies
    {
        public static IEnumerable<Type> Types
        {
            get {
                return new List<Type> {
                    typeof(Guid),
                    typeof(DbContext) };
            }
        }
    }
}
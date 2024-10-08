﻿using Catharsium.Util.Testing.Interfaces;
using NSubstitute;
using System.Reflection;

namespace Catharsium.Util.Testing.Substitutes;

public class InterfaceSubstituteFactory : ISubstituteFactory
{
    public bool CanCreateFor(Type type) {
        return type.GetTypeInfo().IsInterface;
    }


    public object CreateSubstitute(Type type) {
        return Substitute.For([type], []);
    }
}
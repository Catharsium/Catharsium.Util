using Catharsium.Util.Testing.Interfaces;
using System;
using System.Collections.Generic;

namespace Catharsium.Util.Testing.Substitutes;

public class SubstituteService : ISubstituteService
{
    private readonly IEnumerable<ISubstituteFactory> substituteHandlers;


    public SubstituteService(IEnumerable<ISubstituteFactory> substituteHandlers)
    {
        this.substituteHandlers = substituteHandlers;
    }


    public object GetSubstitute(Type type)
    {
        foreach (var substituteHandler in this.substituteHandlers) {
            if (substituteHandler.CanCreateFor(type)) {
                return substituteHandler.CreateSubstitute(type);
            }
        }

        return null;
    }
}
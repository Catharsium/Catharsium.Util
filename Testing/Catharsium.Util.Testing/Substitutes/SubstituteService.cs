using Catharsium.Util.Testing.Interfaces;

namespace Catharsium.Util.Testing.Substitutes;

public class SubstituteService(IEnumerable<ISubstituteFactory> substituteHandlers) : ISubstituteService
{
    private readonly IEnumerable<ISubstituteFactory> substituteHandlers = substituteHandlers;


    public object GetSubstitute(Type type) {
        foreach(var substituteHandler in this.substituteHandlers) {
            if(substituteHandler.CanCreateFor(type)) {
                return substituteHandler.CreateSubstitute(type);
            }
        }

        return null;
    }
}
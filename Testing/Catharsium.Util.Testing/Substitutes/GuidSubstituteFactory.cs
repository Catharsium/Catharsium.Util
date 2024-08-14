using Catharsium.Util.Testing.Interfaces;

namespace Catharsium.Util.Testing.Substitutes;

public class GuidSubstituteFactory : ISubstituteFactory
{
    public bool CanCreateFor(Type type) {
        return type == typeof(Guid);
    }


    public object CreateSubstitute(Type type) {
        return Guid.NewGuid();
    }
}
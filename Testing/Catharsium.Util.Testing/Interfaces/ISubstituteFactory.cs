namespace Catharsium.Util.Testing.Interfaces;

public interface ISubstituteFactory
{
    bool CanCreateFor(Type type);
    object CreateSubstitute(Type type);
}
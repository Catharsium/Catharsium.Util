namespace Catharsium.Util.Testing.Interfaces
{
    public interface ISubstituteFactory
    {
        object GetSubstitute<T>() where T : class;
    }
}
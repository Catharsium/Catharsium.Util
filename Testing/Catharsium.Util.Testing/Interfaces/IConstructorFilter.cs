using Catharsium.Util.Testing.Models;
using System.Reflection;
namespace Catharsium.Util.Testing.Interfaces;

public interface IConstructorFilter
{
    ConstructorInfo GetLargestEligibleConstructor(Type type, List<Dependency> dependencies = null);

    IEnumerable<ConstructorInfo> GetEligibleConstructors(Type type, List<Dependency> dependencies);

    IEnumerable<ConstructorInfo> GetEligibleConstructors(Type type, List<Type> dependencies);
}
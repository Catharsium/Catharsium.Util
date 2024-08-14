using Catharsium.Util.Testing.Models;

namespace Catharsium.Util.Testing.Interfaces;

public interface ITargetFactory<out T> where T : class
{
    T CreateTarget(List<Dependency> dependencies);
}
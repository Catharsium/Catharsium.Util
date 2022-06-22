using System.Threading.Tasks;

namespace Catharsium.Util.IO.Console.ActionHandlers.Interfaces;

public interface IGetActionStep<T>
{
    Task<T> Get();
}
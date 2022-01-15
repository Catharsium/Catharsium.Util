namespace Catharsium.Util.IO.Console.Interfaces;

public interface IActionHandlerStep<T>
{
    Task<T> Run();
}
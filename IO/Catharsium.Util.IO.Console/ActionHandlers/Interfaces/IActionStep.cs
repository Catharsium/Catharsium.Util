namespace Catharsium.Util.IO.Console.ActionHandlers.Interfaces;

public interface ISelectionStep<T>
{
    Task<T> Select();
}
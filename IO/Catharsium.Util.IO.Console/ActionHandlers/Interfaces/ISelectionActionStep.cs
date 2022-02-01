namespace Catharsium.Util.IO.Console.ActionHandlers.Interfaces;

public interface ISelectionActionStep<T>
{
    Task<T> Select();
}
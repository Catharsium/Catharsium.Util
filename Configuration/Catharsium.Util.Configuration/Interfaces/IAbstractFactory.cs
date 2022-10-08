namespace Catharsium.Util.Configuration.Interfaces;

public interface IAbstractFactory<TInterface> where TInterface : class
{
    TInterface Create();
}


public interface IAbstractFactory<TInterface, TParameter> where TInterface : class
{
    TInterface Create(TParameter parameter);
}
using Catharsium.Util.Configuration.Interfaces;
using System;

namespace Catharsium.Util.Configuration.Factories;

public class AbstractFactory<TInterface> : IAbstractFactory<TInterface>
    where TInterface : class
{
    private readonly Func<TInterface> factory;


    public AbstractFactory(Func<TInterface> factory) {
        this.factory = factory;
    }


    public TInterface Create() {
        return factory();
    }
}



public class AbstractFactory<TInterface, TParameter> : IAbstractFactory<TInterface, TParameter>
    where TInterface : class
{
    private readonly Func<TParameter, TInterface> factory;


    public AbstractFactory(Func<TParameter, TInterface> factory) {
        this.factory = factory;
    }


    public TInterface Create(TParameter parameter) {
        return factory(parameter);
    }
}
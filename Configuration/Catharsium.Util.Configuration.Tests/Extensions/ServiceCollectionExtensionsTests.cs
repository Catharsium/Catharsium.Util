using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.Configuration.Factories;
using Catharsium.Util.Configuration.Interfaces;
using Catharsium.Util.Configuration.Tests._Mocks;
using Catharsium.Util.Configuration.Tests.Extensions._Fixture;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Catharsium.Util.Configuration.Tests.Extensions;

[TestClass]
public class ServiceCollectionExtensionsTests
{
    #region RegisterAll

    [TestMethod]
    public void RegisterAll_FindsTypesThatImplementBase_RegistersTypes() {
        var services = Substitute.For<IServiceCollection>();
        var lifetime = ServiceLifetime.Scoped;

        services.RegisterAll<IMockInterface>(lifetime, typeof(MockObject).Assembly);
        services.Received().Add(Arg.Is<ServiceDescriptor>(s => s.ServiceType == typeof(IMockInterface) && s.ImplementationType == typeof(MockObject) && s.Lifetime == lifetime));
    }

    #endregion

    #region RegisterTypes (Dictionary)

    [TestMethod]
    public void RegisterTypes_DictionaryOfTypes_RegistersTypes() {
        var services = Substitute.For<IServiceCollection>();
        var lifetime = ServiceLifetime.Scoped;
        var types = new Dictionary<string, string> {
            { typeof(ImplementationType).AssemblyQualifiedName, typeof(IType).AssemblyQualifiedName }
        };

        services.RegisterTypes(types, lifetime);
        foreach (var type in types) {
            services.Received().Add(Arg.Is<ServiceDescriptor>(sd =>
                sd.ServiceType == Type.GetType(type.Value) &&
                sd.ImplementationType == Type.GetType(type.Key) &&
                sd.Lifetime == lifetime
            ));
        }
    }

    #endregion

    #region RegisterTypes (List)

    [TestMethod]
    public void RegisterTypes_ListOfTypes_RegistersTypes() {
        var services = Substitute.For<IServiceCollection>();
        var lifetime = ServiceLifetime.Scoped;
        var types = new List<string> {
            typeof(ImplementationType).AssemblyQualifiedName
        };

        services.RegisterTypes<IType>(types, lifetime);
        foreach (var type in types) {
            services.Received().Add(Arg.Is<ServiceDescriptor>(sd =>
                sd.ServiceType == typeof(IType) &&
                sd.ImplementationType == Type.GetType(type) &&
                sd.Lifetime == lifetime
            ));
        }
    }

    #endregion

    #region RegisterFactory

    [TestMethod]
    public void RegisterFactory_RegistersTypeAndFactory() {
        var services = Substitute.For<IServiceCollection>();

        services.RegisterFactory<IType, ImplementationType>();
        services.Received().Add(Arg.Is<ServiceDescriptor>(sd =>
            sd.ServiceType == typeof(IType) &&
            sd.ImplementationType == typeof(ImplementationType) &&
            sd.Lifetime == ServiceLifetime.Transient
        ));
        services.Received().Add(Arg.Is<ServiceDescriptor>(sd =>
            sd.ServiceType == typeof(Func<IType>) &&
            sd.Lifetime == ServiceLifetime.Singleton
        ));
        services.Received().Add(Arg.Is<ServiceDescriptor>(sd =>
            sd.ServiceType == typeof(IAbstractFactory<IType>) &&
            sd.ImplementationType == typeof(AbstractFactory<IType>) &&
            sd.Lifetime == ServiceLifetime.Singleton
        ));
    }


    [TestMethod]
    public void RegisterFactoryWithParameter_RegistersTypeAndFactory() {
        var services = Substitute.For<IServiceCollection>();

        services.RegisterFactoryWithParameter<IType, ImplementationType, string>();
        services.Received().Add(Arg.Is<ServiceDescriptor>(sd =>
            sd.ServiceType == typeof(Func<string, IType>) &&
            sd.Lifetime == ServiceLifetime.Singleton
        ));
        services.Received().Add(Arg.Is<ServiceDescriptor>(sd =>
            sd.ServiceType == typeof(IAbstractFactory<IType, string>) &&
            sd.ImplementationType == typeof(AbstractFactory<IType, string>) &&
            sd.Lifetime == ServiceLifetime.Singleton
        ));
    }

    #endregion
}
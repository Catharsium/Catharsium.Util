﻿using Catharsium.Util.IO.Configuration;
using Catharsium.Util.IO.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.IO.Tests.Configuration
{
    [TestClass]
    public class IORegistrationTests
    {
        [TestMethod]
        public void AddFileSync_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();

            serviceCollection.AddUtilIO();
            serviceCollection.Received().Add(Arg.Is<ServiceDescriptor>(d => d.ServiceType == typeof(IFileFactory)));
        }
    }
}
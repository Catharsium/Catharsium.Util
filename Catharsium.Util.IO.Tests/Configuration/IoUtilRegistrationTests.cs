﻿using Catharsium.Util.IO.Configuration;
using Catharsium.Util.IO.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.IO.Tests.Configuration
{
    [TestClass]
    public class IoUtilRegistrationTests
    {
        [TestMethod]
        public void AddIoUtilities_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var config = Substitute.For<IConfiguration>();

            serviceCollection.AddIoUtilities(config);
            serviceCollection.Received().Add(Arg.Is<ServiceDescriptor>(d => d.ServiceType == typeof(IFileFactory)));
        }
    }
}
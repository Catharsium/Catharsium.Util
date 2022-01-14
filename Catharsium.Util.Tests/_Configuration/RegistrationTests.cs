using Catharsium.Util._Configuration;
using Catharsium.Util.Comparing;
using Catharsium.Util.Comparing.Sorting;
using Catharsium.Util.Interfaces;
using Catharsium.Util.Reflection.Types;
using Catharsium.Util.Testing.Extensions;
using Catharsium.Util.Time.Format;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;

namespace Catharsium.Util.Tests._Configuration
{
    [TestClass]
    public class RegistrationTests
    {
        [TestMethod]
        public void AddCatharsiumUtilities_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var config = Substitute.For<IConfiguration>();

            serviceCollection.AddCatharsiumUtilities(config);
            serviceCollection.ReceivedRegistration<IEnumerableSorter<decimal>, QuickSorter<decimal>>();
            serviceCollection.ReceivedRegistration<ITypesRetriever, TypesRetriever>();

            serviceCollection.ReceivedRegistration<IComparer<decimal>, DecimalComparer>();
            serviceCollection.ReceivedRegistration<IComparer<int>, IntComparer>();
            serviceCollection.ReceivedRegistration<IComparer<string>, StringLengthComparer>();

            serviceCollection.ReceivedRegistration<ITimeFormatParser, TimeFormatParser>();
        }
    }
}
using Catharsium.Util.Testing.Extensions;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Exceptions;

namespace Catharsium.Util.Testing.Tests.Extensions
{
    [TestClass]
    public class ServiceCollectionExtensionsTests
    {
        #region WasRegistered<I>

        [TestMethod]
        public void WasRegistered_ServiceCollectionAddCalled_DoesNotThrowAnException()
        {
            var target = Substitute.For<IServiceCollection>();
            target.AddScoped<IMockInterface1>();
            ServiceCollectionExtensions.WasRegistered<IMockInterface1>(target);
        }


        [TestMethod]
        [ExpectedException(typeof(ReceivedCallsException))]
        public void WasRegistered_DifferentInterfaceRegistered_ThrowAnException()
        {
            var target = Substitute.For<IServiceCollection>();
            target.AddScoped<IMockInterface1>();
            ServiceCollectionExtensions.WasRegistered<IMockInterface2>(target);
        }

        #endregion

        #region WasRegistered<I, T>

        [TestMethod]
        public void WasRegistered_WithImplementation_ServiceCollectionAddCalled_DoesNotThrowAnException()
        {
            var target = Substitute.For<IServiceCollection>();
            target.AddScoped<IMockInterface1, Mock1>();
            ServiceCollectionExtensions.WasRegistered<IMockInterface1, Mock1>(target);
        }


        [TestMethod]
        [ExpectedException(typeof(ReceivedCallsException))]
        public void WasRegistered_WithImplementation_DifferentImplementationRegistered_ThrowAnException()
        {
            var target = Substitute.For<IServiceCollection>();
            target.AddScoped<IMockInterface1, Mock2>();
            ServiceCollectionExtensions.WasRegistered<IMockInterface1, Mock1>(target);
        }

        #endregion
    }
}
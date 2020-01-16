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
        #region ReceivedRegistration<I>

        [TestMethod]
        public void ReceivedRegistration_ServiceCollectionAddCalled_DoesNotThrowAnException()
        {
            var target = Substitute.For<IServiceCollection>();
            target.AddScoped<IMockInterface1>();
            target.ReceivedRegistration<IMockInterface1>();
        }


        [TestMethod]
        [ExpectedException(typeof(ReceivedCallsException))]
        public void ReceivedRegistration_DifferentInterfaceRegistered_ThrowAnException()
        {
            var target = Substitute.For<IServiceCollection>();
            target.AddScoped<IMockInterface1>();
            target.ReceivedRegistration<IMockInterface2>();
        }

        #endregion

        #region ReceivedRegistration<I, T>

        [TestMethod]
        public void ReceivedRegistration_WithImplementation_ServiceCollectionAddCalled_DoesNotThrowAnException()
        {
            var target = Substitute.For<IServiceCollection>();
            target.AddScoped<IMockInterface1, Mock1>();
            ServiceCollectionExtensions.ReceivedRegistration<IMockInterface1, Mock1>(target);
        }


        [TestMethod]
        [ExpectedException(typeof(ReceivedCallsException))]
        public void ReceivedRegistration_WithImplementation_DifferentImplementationRegistered_ThrowAnException()
        {
            var target = Substitute.For<IServiceCollection>();
            target.AddScoped<IMockInterface1, Mock2>();
            ServiceCollectionExtensions.ReceivedRegistration<IMockInterface1, Mock1>(target);
        }

        #endregion
    }
}
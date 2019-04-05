using Catharsium.Util.Caching;
using Catharsium.Util.Testing;
using Catharsium.Util.Tests._Mocks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Tests.Caching
{
    [TestClass]
    public class CachedServiceTests : TestFixture<CachedService<MockService>>
    {
        #region Fixture

        protected MockService Instance { get; set; }


        [TestInitialize]
        public void SetupData()
        {
            this.SetDependency(new MockService());
        }

        #endregion

        #region GetData<TResult>

        [TestMethod]
        public void GetData_InvalidReturnType_ReturnsDefault()
        {
            var input = "My input";
            var actual = this.Target.GetData<CachedServiceTests>(nameof(this.Instance.ReadData), input);
            Assert.AreEqual(default(string), actual);
        }


        [TestMethod]
        public void GetData_NewValidCall_ReturnsExpected()
        {
            var expected = "My input string";
            var actual = this.Target.GetData<string>(nameof(this.Instance.ReadData), expected);
            Assert.AreEqual(expected, actual);
            this.GetDependency<IMemoryCache>().Received(1).Get<string>(Arg.Any<string>());
            this.GetDependency<IMemoryCache>().Received(1).Set(Arg.Any<string>(), expected);
        }


        [TestMethod]
        public void GetData_ExistingValidCall_DoesNotCacheResult()
        {
            var input = "My input string";
            var expected = "My expected string";
            this.GetDependency<IMemoryCache>().TryGetValue(Arg.Any<string>(), out string _).Returns(x => {
                x[1] = expected;
                return true;
            });

            var actual = this.Target.GetData<string>(nameof(this.Instance.ReadData), input);
            Assert.AreEqual(expected, actual);
            this.GetDependency<IMemoryCache>().DidNotReceive().Set(Arg.Any<string>(), expected);
        }

        #endregion
    }
}
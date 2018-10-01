using Catharsium.Util.Caching;
using Catharsium.Util.Tests._Mocks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Tests.Caching
{
    [TestClass]
    public class CachedServiceTests
    {
        #region Fixture

        public MockService Instance { get; set; }

        public IMemoryCache Cache { get; set; }
        public CachedService<MockService> Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.Instance = new MockService();
            this.Cache = Substitute.For<IMemoryCache>();
            this.Target = new CachedService<MockService>(this.Instance, this.Cache);
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
            this.Cache.Received(1).Get<string>(Arg.Any<string>());
            this.Cache.Received(1).Set(Arg.Any<string>(), expected);
        }


        [TestMethod]
        public void GetData_ExistingValidCall_DoesNotCacheResult()
        {
            var input = "My input string";
            var expected = "My expected string";
            this.Cache.Get<string>(Arg.Any<string>()).Returns(expected);

            var actual = this.Target.GetData<string>(nameof(this.Instance.ReadData), input);
            Assert.AreEqual(expected, actual);
            this.Cache.DidNotReceive().Set(Arg.Any<string>(), expected);
        }

        #endregion
    }
}
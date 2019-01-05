using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing.Tests
{
    [TestClass]
    public class TestFixtureTests
    {
        #region Fixture

        private TestFixture<MockObject> Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.Target = new TestFixture<MockObject>();
        }
        
        #endregion

        [TestMethod]
        public void Constructor_InitializesTarget()
        {
            var target = new TestFixture<TestFixtureTests>();
            Assert.IsNotNull(target.Target);
        }

        
        [TestMethod]
        public void Constructor_CreatesSubstitutesForDependencies_IgnoresClassParameters()
        {
            Assert.IsNotNull(this.Target.Dependencies);
            Assert.AreEqual(2, this.Target.Dependencies.Count);
            Assert.IsTrue(this.Target.Dependencies.ContainsKey(typeof(IMockInterface1)));
            Assert.IsTrue(this.Target.Dependencies.ContainsKey(typeof(IMockInterface2)));
        }


        #region GetDependency

        [TestMethod]
        public void GetDependency_ValidType_ReturnsDependency()
        {
            var expected = "";
            this.Target.Dependencies[typeof(string)] = expected;
            var actual = this.Target.GetDependency<string>();
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void GetDependency_InvalidType_ReturnsNull()
        {
            var actual = this.Target.GetDependency<string>();
            Assert.IsNull(actual);
        }

        #endregion
    }
}
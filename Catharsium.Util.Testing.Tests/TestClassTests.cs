using Catharsium.Util.Testing.Tests.Mocks;
using Catharsium.Util.Tests.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing.Tests
{
    [TestClass]
    public class TestClassTests
    {
        [TestMethod]
        public void Constructor_InitializesTarget()
        {
            var target = new TestClass<TestClassTests>();
            Assert.IsNotNull(target.Target);
        }


        [TestMethod]
        public void Constructor_CreatesSubstitutesForDependencies_IgnoresClassParameters()
        {
            var target = new TestClass<MockObject>();
            Assert.IsNotNull(target.Dependencies);
            Assert.AreEqual(2, target.Dependencies.Count);
            Assert.IsTrue(target.Dependencies.ContainsKey(typeof(IMockInterface1)));
            Assert.IsTrue(target.Dependencies.ContainsKey(typeof(IMockInterface2)));
        }
    }
}
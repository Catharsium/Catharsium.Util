using Catharsium.Util.Testing.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing.Tests.Models
{
    [TestClass]
    public class DependencyComparerTests
    {
        #region Fixture

        private DependencyComparer Target { get; set; }

        private Dependency Dependency { get; set; }


        [TestInitialize]
        public void SetupDependencies()
        {
            this.Dependency = new Dependency(typeof(object), "My name");
            this.Target = new DependencyComparer();
        }

        #endregion

        #region Equals

        [TestMethod]
        public void Equals_ObjectAndItself_ReturnsTrue()
        {
            var actual = this.Target.Equals(this.Dependency, this.Dependency);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Equals_ObjectAndCopy_ReturnsTrue()
        {
            var copy = new Dependency(this.Dependency.Type, this.Dependency.Name);
            var actual = this.Target.Equals(this.Dependency, copy);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Equals_DifferentType_ReturnsFalse()
        {
            var other = new Dependency(typeof(Dependency), this.Dependency.Name);
            var actual = this.Target.Equals(this.Dependency, other);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Equals_DifferentName_ReturnsFalse()
        {
            var other = new Dependency(this.Dependency.Type, this.Dependency.Name + "Other");
            var actual = this.Target.Equals(this.Dependency, other);
            Assert.IsFalse(actual);
        }

        #endregion

        #region GetHashCode

        [TestMethod]
        public void GetHashCode_ReturnsObjectHashCode()
        {
            var expected = this.Dependency.GetHashCode();
            var actual = this.Target.GetHashCode(this.Dependency);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
using System.Linq;
using Catharsium.Util.Testing.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

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

        #region Constructor

        [TestMethod]
        public void Constructor_InitializesTarget()
        {
            Assert.IsNotNull(this.Target.Target);
        }

        
        [TestMethod]
        public void Constructor_CreatesSubstitutesForDependencies_IgnoresClassParameters()
        {
            Assert.IsNotNull(this.Target.Dependencies);
            Assert.AreEqual(2, this.Target.Dependencies.Count);
            Assert.IsTrue(this.Target.Dependencies.ContainsKey(typeof(IMockInterface1)));
            Assert.IsTrue(this.Target.Dependencies.ContainsKey(typeof(IMockInterface2)));
        }

        #endregion

        #region InitializeTarget

        //public void InitializeTarget()
        //{
        //    var constructor = this.GetLargestEligableConstructor();
        //    var parameters = constructor.GetParameters();
        //    var arguments = new List<object>();
        //    foreach (var parameter in parameters)
        //    {
        //        arguments.Add(this.Dependencies[parameter.ParameterType]);
        //    }

        //    this.Target = constructor.Invoke(arguments.ToArray()) as T;
        //}

        #endregion

        #region GetLargestEligibleConstructor

        [TestMethod]
        public void GetLargestEligibleConstructor_NoAddedDependencies_ReturnsLargestConstructor()
        {
            var actual = this.Target.GetLargestEligibleConstructor();
            Assert.AreEqual(2, actual.GetParameters().Length);
        }


        [TestMethod]
        public void GetLargestEligibleConstructor_AddedDependencyFromIneligibleConstructor_ReturnsLargetsConstructor()
        {
            this.Target.Dependencies[typeof(string)] = "My string";
            var actual = this.Target.GetLargestEligibleConstructor();
            Assert.AreEqual(3, actual.GetParameters().Length);
        }

        #endregion

        #region GetEligibleConstructors

        [TestMethod]
        public void GetEligibleConstructors_NoAddedDependencies_ReturnsConstructorsThatOnlyRequireInterfaces()
        {
            var actual = this.Target.GetEligibleConstructors();
            var actualList = actual.ToList();
            Assert.AreEqual(2, actualList.Count);
        }


        [TestMethod]
        public void GetEligibleConstructors_AddedDependencyFromIneligibleConstructor_IncludesConstructor()
        {
            this.Target.Dependencies[typeof(string)] = "My string";
            var actual = this.Target.GetEligibleConstructors();
            var actualList = actual.ToList();
            Assert.AreEqual(3, actualList.Count);
        }

        #endregion

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

        #region SetDependency

        [TestMethod]
        public void SetDependency_NewDependency_IsAddedToDependenciesList()
        {
            var expected = "My string";
            this.Target.SetDependency(expected);
            Assert.IsTrue(this.Target.Dependencies.ContainsKey(expected.GetType()));
            Assert.AreEqual(expected, this.Target.Dependencies[expected.GetType()]);
        }
        
        
        [TestMethod]
        public void SetDependency_ExistingDependency_ReplacesCurrentInDependenciesList()
        {
            var expected = Substitute.For<IMockInterface1>();
            var type = typeof(IMockInterface1);
            this.Target.SetDependency(expected);
            Assert.IsTrue(this.Target.Dependencies.ContainsKey(type));
            Assert.AreEqual(expected, this.Target.Dependencies[type]);
        }


        [TestMethod]
        public void SetDependency_DependencyInMostSpecificConstructor_IsAddedToTarget()
        {
            var expected = "My string";
            this.Target.SetDependency(expected);
            Assert.AreEqual(expected, this.Target.Target.StringDependency);
        }

        #endregion
    }
}
using System.ComponentModel.DataAnnotations;
using Catharsium.Util.Attributes.Extensions;
using Catharsium.Util.Tests._Mocks;
using Catharsium.Util.Web.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Attributes
{
    [TestClass]
    public class AttributeHelperTests
    {
        #region GetAttribute<T>(instance)

        [TestMethod]
        public void GetAttribute_InstanceWithRequestedAttribute_ReturnsAttribute()
        {
            var subject = new MockObjectWithDisplayAttribute();
            var actual = subject.GetAttribute<DisplayAttribute>();
            Assert.IsNotNull(actual);
            Assert.AreEqual("My class name", actual.Name);
        }


        [TestMethod]
        public void GetAttribute_InstanceWithoutRequestedAttribute_ReturnsNull()
        {
            var subject = new AttributeHelperTests();
            var actual = subject.GetAttribute<DisplayAttribute>();
            Assert.IsNull(actual);
        }

        #endregion

        #region GetAttribute<T>(instance, propertyName)

        [TestMethod]
        public void GetAttribute_PropertyWithRequestedAttribute_ReturnsAttribute()
        {
            var subject = new MockObjectWithDisplayAttribute();
            var actual = subject.GetAttribute<DisplayAttribute>(nameof(subject.PropertyWithDisplayAttribute));
            Assert.IsNotNull(actual);
            Assert.AreEqual("My property name", actual.Name);
        }


        [TestMethod]
        public void GetAttribute_PropertyWithDifferentAttribute_ReturnsNull()
        {
            var subject = new MockObjectWithDisplayAttribute();
            var actual = subject.GetAttribute<BsnAttribute>(nameof(subject.PropertyWithoutAttributes));
            Assert.IsNull(actual);
        }


        [TestMethod]
        public void GetAttribute_PropertyWithoutRequestedAttribute_ReturnsNull()
        {
            var subject = new MockObjectWithDisplayAttribute();
            var actual = subject.GetAttribute<DisplayAttribute>(nameof(subject.PropertyWithoutAttributes));
            Assert.IsNull(actual);
        }

        #endregion
    }
}
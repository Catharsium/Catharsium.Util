using Catharsium.Util.Testing;
using Catharsium.Util.Tests._Mocks;
using Catharsium.Util.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Validation
{
    [TestClass]
    public class RequiredWithAttributeTests : TestFixture<RequiredWithAttribute>
    {
        [TestMethod]
        public void IsValid_WithValue_OtherPropertyIsEmpty_ReturnsFalse()
        {
            var mockObject = new MockObject();
            this.Target = new RequiredWithAttribute(nameof(MockObject.Property2));

            var actual = this.Target.IsValid("My value", mockObject);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void IsValid_WithValue_OtherPropertyHasValue_ReturnsTrue()
        {
            var mockObject = new MockObject {
                Property2 = "My property 2"
            };
            this.Target = new RequiredWithAttribute(nameof(MockObject.Property2));

            var actual = this.Target.IsValid("My value", mockObject);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void IsValid_WithValue_MultipleOtherPropertiesWithValue_ReturnsTrue()
        {
            var mockObject = new MockObject {
                Property2 = "My property 2",
                Property3 = "My property 3"
            };
            this.Target = new RequiredWithAttribute(nameof(MockObject.Property2), nameof(MockObject.Property3));

            var actual = this.Target.IsValid("My value", mockObject);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void IsValid_WithValue_MultipleOtherPropertiesOneWithoutValue_ReturnsTrue()
        {
            var mockObject = new MockObject {
                Property3 = "My property 3"
            };
            this.Target = new RequiredWithAttribute(nameof(MockObject.Property2), nameof(MockObject.Property3));

            var actual = this.Target.IsValid("My value", mockObject);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void IsValid_WithoutValue_ReturnsTrue()
        {
            var mockObject = new MockObject();
            this.Target = new RequiredWithAttribute(nameof(MockObject.Property2));

            var actual = this.Target.IsValid("", mockObject);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void IsValid_NullValue_ReturnsTrue()
        {
            var mockObject = new MockObject();
            this.Target = new RequiredWithAttribute(nameof(MockObject.Property2));

            var actual = this.Target.IsValid(null, mockObject);
            Assert.IsTrue(actual);
        }
    }
}

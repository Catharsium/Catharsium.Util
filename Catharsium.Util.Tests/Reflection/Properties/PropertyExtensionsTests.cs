using Catharsium.Util.Reflection.Properties;
using Catharsium.Util.Tests._Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Reflection.Properties
{
    class PropertyExtensionsTests
    {
        #region SetProperty

        [TestMethod]
        public void SetProperty_ValidName_SetsValue()
        {
            var fixture = new ObjectWithAccessProperties();
            var expected = "My value";

            fixture.SetProperty(nameof(fixture.WritableProperty), expected);
            Assert.AreEqual(expected, fixture.WritableProperty);
        }


        [TestMethod]
        public void SetProperty_InvalidName_DoesNotSetValue()
        {
            var fixture = new ObjectWithAccessProperties();
            var value = "My value";

            fixture.SetProperty(nameof(fixture.WritableProperty) + "Other", value);
            Assert.IsNull(fixture.WritableProperty);
        }


        [TestMethod]
        public void SetProperty_UnwritableProperty_DoesNotSetValue()
        {
            var fixture = new ObjectWithAccessProperties();
            var value = "My value";

            fixture.SetProperty(nameof(fixture.ReadOnlyProperty) + "Other", value);
            Assert.IsNull(fixture.WritableProperty);
        }

        #endregion

        #region GetPropertiesWithValue

        [TestMethod]
        public void GetPropertiesWithValue_ReturnsPropertiesWithValue()
        {
            var fixture = new ObjectWithMultipleProperties {
                Property2 = "My property 2"
            };

            var actual = fixture.GetPropertiesWithValue();
            Assert.AreEqual(1, actual.Length);
            Assert.AreEqual(nameof(fixture.Property2), actual[0].Name);
        }

        #endregion
    }
}
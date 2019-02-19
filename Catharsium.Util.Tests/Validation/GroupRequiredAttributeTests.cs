using Catharsium.Util.Testing;
using Catharsium.Util.Tests._Mocks;
using Catharsium.Util.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Validation
{
    [TestClass]
    public class GroupRequiredAttributeTests : TestFixture<GroupRequiredAttribute>
    {
        [TestMethod]
        public void IsValid_ValueHasAValue_ReturnsTrue()
        {
            var model = new MockObject { Property1 = "1" };
            this.Target = new GroupRequiredAttribute("Group 1");
            var actual = this.Target.IsValid(model, model.Property1);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void IsValid_OtherGroupMemberHasValue_ReturnsTrue()
        {
            var model = new MockObject { Property2 = "2" };
            this.Target = new GroupRequiredAttribute("Group 1");
            var actual = this.Target.IsValid(model, model.Property1);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void IsValid_EmptyStringValues_ReturnsFalse()
        {
            var model = new MockObject { Property1 = "", Property2 = "", Property3 = "", Property4 = "" };
            this.Target = new GroupRequiredAttribute("Group 1");
            var actual = this.Target.IsValid(model, model.Property1);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void IsValid_OnlyOtherGroupHasValues_ReturnsFalse()
        {
            var model = new MockObject { Property3 = "3", Property4 = "4" };
            this.Target = new GroupRequiredAttribute("Group 1");
            var actual = this.Target.IsValid(model, model.Property1);
            Assert.IsTrue(actual);
        }
    }
}
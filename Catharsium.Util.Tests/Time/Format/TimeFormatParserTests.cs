using Catharsium.Util.Testing;
using Catharsium.Util.Time.Format;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Time.Format
{
    [TestClass]
    public class TimeFormatParserTests : TestFixture<TimeFormatParser>
    {
        #region Parse Complex

        [TestMethod]
        public void Parse_Complex_ReturnsPeriodWithAllParts()
        {
            var expected = new TimePeriod {
                Years = 1,
                Weeks = 2,
                Days = 3,
                Hours = 4,
                Minutes = 5,
                Seconds = 6
            };

            var actual = this.Target.Parse(expected.ToString());
            Assert.AreEqual(expected.Years, actual.Years);
            Assert.AreEqual(expected.Weeks, actual.Weeks);
            Assert.AreEqual(expected.Days, actual.Days);
            Assert.AreEqual(expected.Hours, actual.Hours);
            Assert.AreEqual(expected.Minutes, actual.Minutes);
            Assert.AreEqual(expected.Seconds, actual.Seconds);
        }

        #endregion

        #region Parse Single

        [TestMethod]
        public void Parse_Single_y_ReturnsYears()
        {
            var quantity = 3;
            var actual = this.Target.Parse(quantity, "y");
            Assert.AreEqual(quantity, actual.Years);
        }


        [TestMethod]
        public void Parse_Single_w_ReturnsWeeks()
        {
            var quantity = 3;
            var actual = this.Target.Parse(quantity, "w");
            Assert.AreEqual(quantity, actual.Weeks);
        }


        [TestMethod]
        public void Parse_Single_d_ReturnsDays()
        {
            var quantity = 3;
            var actual = this.Target.Parse(quantity, "d");
            Assert.AreEqual(quantity, actual.Days);
        }


        [TestMethod]
        public void Parse_Single_h_ReturnsHours()
        {
            var quantity = 3;
            var actual = this.Target.Parse(quantity, "h");
            Assert.AreEqual(quantity, actual.Hours);
        }

        [TestMethod]
        public void Parse_Single_w_ReturnsMinutes()
        {
            var quantity = 3;
            var actual = this.Target.Parse(quantity, "m");
            Assert.AreEqual(quantity, actual.Minutes);
        }


        [TestMethod]
        public void Parse_Single_s_ReturnsSeconds()
        {
            var quantity = 3;
            var actual = this.Target.Parse(quantity, "s");
            Assert.AreEqual(quantity, actual.Seconds);
        }


        [TestMethod]
        public void Parse_Single_IsCaseInsensitive()
        {
            var quantity = 3;
            var actual = this.Target.Parse(quantity, "S");
            Assert.AreEqual(quantity, actual.Seconds);
        }

        #endregion
    }
}
using Catharsium.Util.Tests._Mocks;
using Catharsium.Util.Time.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Catharsium.Util.Tests.Time.Extensions.TimeSpanExtensionsTests
{
    [TestClass]
    public class SumTests
    {
        #region Sum without selector

        [TestMethod]
        public void Sum_SingleTimeSpan_ReturnsIt()
        {
            var timeSpan = new TimeSpan(123L);
            var list = new[] { timeSpan };

            var actual = list.Sum();
            Assert.AreEqual(timeSpan.Ticks, actual.Ticks);
        }


        [TestMethod]
        public void Sum_MultipleTimeSpans_ReturnsSumOfTime()
        {
            var timeSpan = new TimeSpan(123L);
            var list = new[] { timeSpan, timeSpan, timeSpan };

            var actual = list.Sum();
            Assert.AreEqual(timeSpan.Ticks * list.Length, actual.Ticks);
        }


        [TestMethod]
        public void Sum_DifferentTimeSpans_ReturnsSumOfTime()
        {
            var timeSpan1 = new TimeSpan(123L);
            var timeSpan2 = new TimeSpan(234L);
            var list = new[] { timeSpan1, timeSpan2 };

            var actual = list.Sum();
            Assert.AreEqual(timeSpan1.Ticks + timeSpan2.Ticks, actual.Ticks);
        }


        [TestMethod]
        public void Sum_EmptyTimeSpan_IsIgnored()
        {
            var timeSpan1 = new TimeSpan(123L);
            var list = new[] { timeSpan1, new TimeSpan(0) };

            var actual = list.Sum();
            Assert.AreEqual(timeSpan1.Ticks, actual.Ticks);
        }

        #endregion

        #region Sum with selector

        [TestMethod]
        public void Sum_WithSelector_ReturnsSumOfTimeSpans()
        {
            var element1 = new MockTimeSpanHolder { TimeSpanProperty = new TimeSpan(123L) };
            var element2 = new MockTimeSpanHolder { TimeSpanProperty = new TimeSpan(234L) };
            var list = new[] { element1, element2 };
            var expected = new[] { element1.TimeSpanProperty, element2.TimeSpanProperty }.Sum();

            var actual = list.Sum(e => e.TimeSpanProperty);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
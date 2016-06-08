using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherTest.WebApi.Infrastructure;

namespace WeatherTest.Tests
{
    [TestClass]
    public class WindDirectionTests
    {
        [TestMethod]
        public void DegreeOutOfRange()
        {
            DegreeLessThan0();
            DegreeGeaterThan360();
        }

        private void DegreeLessThan0()
        {
            WindDirection wind = WindDirection.Create(-5);

            Assert.AreEqual(null, wind);
        }

        private void DegreeGeaterThan360()
        {
            WindDirection wind = WindDirection.Create(400);

            Assert.AreEqual(null, wind);
        }

        /// <summary>
        /// If edge value calculated correct for one direction other ok too.
        /// </summary>
        [TestMethod]
        public void SouthStartEdgeValue()
        {
            WindDirection wind = WindDirection.Create(158);

            Assert.AreEqual("South", wind.Direction);
        }

        /// <summary>
        /// If edge value calculated correct for one direction other ok too.
        /// </summary>
        [TestMethod]
        public void SouthEndEdgeValue()
        {
            WindDirection wind = WindDirection.Create(202);

            Assert.AreEqual("South", wind.Direction);
        }

        [TestMethod]
        public void NorthDirection()
        {
            WindDirection wind = WindDirection.Create(12);

            Assert.AreEqual("North", wind.Direction);
        }

        [TestMethod]
        public void EndOfTheScaleNorthDirection()
        {
            WindDirection wind = WindDirection.Create(340);

            Assert.AreEqual("North", wind.Direction);
        }
    }
}

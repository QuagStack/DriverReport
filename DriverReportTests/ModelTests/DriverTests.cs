using System;
using System.Linq;
using DriverReportProcessor.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DriverReportTests.ModelTests
{
    [TestClass]
    public class DriverTests
    {
        Driver _driver = new Driver("Driver Dan");

        #region Model Field Tests

        [TestMethod]
        public void DriverNameTest()
        {
            var newName = "Test";
            _driver.Name = newName;
            Assert.AreEqual(newName, _driver.Name);
        }

        [TestMethod]
        public void DriverNewDriverEmptyTripList()
        {
            Driver driver = new Driver("Driver Dan");
            
            Assert.AreEqual(driver.Trips.Count, 0);
        }

        [TestMethod]
        public void DriverTripsTest()
        {
            Trip tripNew = new Trip("Trip Dan 23:15 00:15 17.3");

            Driver driver = new Driver("Dan");

            driver.Trips.Add(tripNew);

            Assert.AreEqual(tripNew.DriverName, driver.Name);
        }



        #endregion
    }
}

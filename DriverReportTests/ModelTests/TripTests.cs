using Microsoft.VisualStudio.TestTools.UnitTesting;
using DriverReportProcessor.Models;
using System;

namespace DriverReportTests.ModelTests
{
    [TestClass]
    public class TripTests
    {

        Trip trip = new Trip("Trip Dan 07:15 07:45 17.3");

        #region Model Field Tests

        [TestMethod]
        public void TripDriverNameTest()
        {
            var newName = "Test";
            trip.DriverName = newName;
            Assert.AreEqual(newName, trip.DriverName);
        }

        [TestMethod]
        public void TripStartTimeTest()
        {
            var startTime = DateTime.Now;
            trip.StartTime = startTime;
            Assert.AreEqual(startTime, trip.StartTime);
        }

        [TestMethod]
        public void TripEndTimeTest()
        {
            var endTime = DateTime.Now;
            trip.EndTime = endTime;
            Assert.AreEqual(endTime, trip.EndTime);
        }

        [TestMethod]
        public void TripTripLengthTest()
        {
            var tripLength = 15.25;
            trip.TripLength = 15.25;
            Assert.AreEqual(tripLength, trip.TripLength);
        }

        [TestMethod]
        public void TripAverageSpeedTest()
        {
            var averageSpeed = 15.25;
            trip.AverageSpeed = 15.25;
            Assert.AreEqual(averageSpeed, trip.AverageSpeed);
        }

        #endregion


        [TestMethod]
        public void CalculateAverageSpeedMakesDrivingAfterTrueWithNegativeTimeDriven()
        {
            Trip tripNew = new Trip("Trip Dan 23:15 00:15 17.3");
            Assert.AreEqual(true, tripNew.DrivingAfterMidnight);
        }

        [TestMethod]
        public void CalculateAverageSpeedMakesDrivingAfterFalseWithPositiveTimeDriven()
        {
            Trip tripNew = new Trip("Trip Dan 11:15 11:45 17.3");
            Assert.AreEqual(false, tripNew.DrivingAfterMidnight);
        }
    }
}

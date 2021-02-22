using System;
using System.Collections.Generic;

namespace DriverReportProcessor.Models
{
    public class Driver
    {
        public Driver(string name)
        {
            Name = name;
            Trips = new List<Trip>();
        }

        public string Name { get; set; }
        public List<Trip> Trips { get; set; }

        public int GetTripLength()
        {
            var tripsLength = 0.0;
            foreach (Trip trip in Trips)
            {
                tripsLength = tripsLength + trip.TripLength;
            }
            return Convert.ToInt32(tripsLength);
        }

        public int GetAverageSpeedOfTrips()
        {
            var averageSpeed = 0.0;
            foreach (Trip trip in Trips)
            {
                averageSpeed = averageSpeed + trip.AverageSpeed;
            }
            return Convert.ToInt32(averageSpeed);
        }
    }
}

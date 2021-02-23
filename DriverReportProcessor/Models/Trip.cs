using System;
namespace DriverReportProcessor.Models
{
    public class Trip
    {
        public Trip(string line)
        {
            var tripLineArray = line.Split(' ');
            DrivingAfterMidnight = false;
            DriverName = tripLineArray[1];
            StartTime = DateTime.ParseExact(tripLineArray[2], "HH:mm", System.Globalization.CultureInfo.CurrentUICulture);
            EndTime = DateTime.ParseExact(tripLineArray[3], "HH:mm", System.Globalization.CultureInfo.CurrentCulture);
            TripLength = double.Parse(tripLineArray[4]);
            CalculateAverageSpeed();
        }

        public string DriverName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double TripLength { get; set; }
        public double AverageSpeed { get; set; }
        public bool DrivingAfterMidnight { get; set; }

        public void CalculateAverageSpeed()
        {
            TimeSpan timeDriven = EndTime.Subtract(StartTime);

            if (timeDriven.TotalMinutes <= 0)
            {
                DrivingAfterMidnight = true;
            }

            AverageSpeed = TripLength / (timeDriven.TotalMinutes / 60);
        }

    }
}

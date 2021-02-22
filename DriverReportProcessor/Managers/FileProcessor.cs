using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DriverReportProcessor.Models;

namespace DriverReportProcessor.Managers
{
    public class FileProcessor
    {
        private string _filePath { get; set; }
        private List<Driver> _drivers { get; set; }

        public FileProcessor(string filePath)
        {
            if (File.Exists(filePath))
            {
                _filePath = filePath;
                _drivers = new List<Driver>();
            }
            else
            {
                throw new Exception("Input File Does Not Exist.");
            }

        }

        public void ProcessFile()
        {
            try
            {
                Console.WriteLine("Reading input file...");
                ReadFile();
                //Now that we have a list of Drivers and Trips, write out the file.
                Console.WriteLine("Generating output....");
                var lines = GenerateOutputLines();
                Console.WriteLine("Writing File....");
                WriteFile(lines);
                Console.WriteLine("Success");
                Console.WriteLine("Press Enter To Exit....");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an exception thrown while trying to process the file: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Press Enter To Exit....");
                Console.ReadLine();
            }

        }

        private void ReadFile()
        {
            //Read Text File
            string line;
            using (System.IO.StreamReader file = new System.IO.StreamReader(_filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    //Determine the type of line that this is.
                    if (isDynamicLineType(line, "Driver"))
                    {
                        //Add driver
                        _drivers.Add(new Driver(line.Split(' ')[1]));
                    }
                    else if (isDynamicLineType(line, "Trip"))
                    {
                        //This is a trip.

                        //Does the driver exist in our collection?
                        Driver driver = _drivers.Where(x => x.Name == line.Split(' ')[1]).FirstOrDefault();

                        if (driver != null)
                        {
                            //This driver exists, add new trip to the driver
                            try
                            {
                                var trip = new Trip(line);

                                if (trip.AverageSpeed >= 100.0 || trip.AverageSpeed <= 5.0 || trip.DrivingAfterMidnight)
                                {
                                    continue;
                                }
                                driver.Trips.Add(trip);
                            }
                            catch (Exception e)
                            {
                                throw e;
                            }

                        }

                    }
                    else
                    {
                        //Throw Exception For This Line, Not Formatted Properly

                    }
                }
            }
        }

        private string[] GenerateOutputLines()
        {
            List<string> lines = new List<string>();
            foreach (var driver in _drivers)
            {
                string line = $"{driver.Name}: ";
                if (driver.Trips.Count > 0)
                {
                    line = line + $"{driver.GetTripLength()} miles @ {driver.GetAverageSpeedOfTrips()} mph";
                }
                else
                {
                    //No Trips, so just list the driver with 0 distance
                    line = line + "0 miles";

                }
                lines.Add(line);
            }
            return lines.ToArray();
        }

        private void WriteFile(string[] lines)
        {

            File.WriteAllLines("Result.txt", lines);
        }

        private bool isDynamicLineType(string line, string lineType)
        {
            if (Regex.Match(line, $"^{lineType}").Success)
            {
                //This is a driver line, create a new driver
                return true;
            }
            return false;
        }
    }
}

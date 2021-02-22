# Driver Report


Driver Report is a .NET 5 solution written in C#. It is composed of two different projects: DriverReportProcessor and DriverReportTests.

## Features

- Import a text file via a command line argument and generate a text file output that curates drivers and their trips.
- Unit Tests

## DriverReportProcessor
This is a console application that takes a file path as a command line argument and then creates a report file in the build location of the 
application. 

Models live in the model folder.
Managers live in the manager folder. 

The "FileProcessor" class runs the entire process. This class takes a file path and attempts to parse it and generate an output.
Regex matching is being used to parse the lines to determine what kind of line is being dealt with. 

##### Installation

DriverReportProcessor requires the machine running it to have .NET 5 runtime and/or SDK installed on the machine.

## DriverReportTests
DriverReportTests is a unit tests project that references the DriverReportProcessor project. There are unit tests for models and their fields, as well as the FileProcessor. 

Model fields have their own unit tests in order to verify that getting and setting fields returns expected values. 





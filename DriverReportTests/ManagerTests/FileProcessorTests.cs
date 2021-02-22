using System;
using System.Linq;
using DriverReportProcessor.Managers;
using DriverReportProcessor.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DriverReportTests.ManagerTests
{
    [TestClass]
    public class FileProcessorTests
    {
        

        [TestMethod]
        [ExpectedException(typeof(Exception), "Input File Does Not Exist.")]
        public void FileProcessorTestFileDoesntExistException()
        {
            FileProcessor fileProcessor = new FileProcessor("../../asdfasdfasdverczxcs.txt");
        }
    }
}

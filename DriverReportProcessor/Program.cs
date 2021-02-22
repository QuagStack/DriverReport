using System;
using DriverReportProcessor.Managers;

namespace DriverReportProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileProcessor fileProcessor = new FileProcessor(args[0]);
                fileProcessor.ProcessFile();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                Console.ReadLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApplication
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("File Log: " + message);
        }
    }
}

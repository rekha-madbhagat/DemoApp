using System;

namespace TestWebApplication
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Console Log: " + message);
        }
    }
}

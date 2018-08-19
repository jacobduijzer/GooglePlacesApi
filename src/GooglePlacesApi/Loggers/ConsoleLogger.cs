using System;
using GooglePlacesApi.Interfaces;

namespace GooglePlacesApi.Loggers
{
    public class ConsoleLogger : IRefitLogger
    {
        public void Write(string message) => Console.WriteLine(message);
    }
}

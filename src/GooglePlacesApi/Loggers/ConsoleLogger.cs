using System;
using GooglePlacesApi.Abstractions.Interfaces;

namespace GooglePlacesApi.Loggers
{
    public class ConsoleLogger : IRefitLogger
    {
        public void Write(string message) => Console.WriteLine(message);
    }
}

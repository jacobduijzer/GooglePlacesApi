using GooglePlacesApi.Interfaces;
using Xunit.Abstractions;

namespace GooglePlacesApi.Tests.Helpers
{
    public class TestLogger : IRefitLogger
    {
        private ITestOutputHelper _output;

        public TestLogger(ITestOutputHelper output) => _output = output;

        public void Write(string message) => _output.WriteLine(message);
    }
}

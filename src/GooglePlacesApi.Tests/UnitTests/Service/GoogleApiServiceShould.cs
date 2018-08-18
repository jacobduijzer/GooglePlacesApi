using FluentAssertions;
using GooglePlacesApi.Abstractions.Models;
using Xunit;

namespace GooglePlacesApi.Tests.UnitTests.Service
{
    public class GoogleApiServiceShould
    {
        public GoogleApiServiceShould()
        {
        }

        [Fact]
        public void Construct()
        {
            var service = new GooglePlacesApiService(GoogleApiSettings.Builder.WithApiKey("testkey").Build());
            service.Should()
                   .BeOfType<GooglePlacesApiService>();
        }
    }
}

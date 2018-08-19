using FluentAssertions;
using GooglePlacesApi.Abstractions.Models;
using Xunit;
using System;

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

        [Fact]
        public void ThrowWhenSettingsAreNull()
        {
            var action = new Action(() => new GooglePlacesApiService(null));
            action.Should()
                  .Throw<ArgumentNullException>();
        }
    }
}

using System;
using FluentAssertions;
using GooglePlacesApi.Models;
using Xunit;
using System.Threading.Tasks;

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

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void ThrowWhenSearchTextIsNullOrEmpty(string input)
        {
            var service = new GooglePlacesApiService(GoogleApiSettings.Builder.WithApiKey("testkey").Build());
            var action = new Func<Task>(async() => await service.GetPredictionsAsync(input));
            action.Should()
                  .Throw<ArgumentNullException>()
                  .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: searchText");
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void ThrowWhenPlaceIdIsNullOrEmpty(string input)
        {
            var service = new GooglePlacesApiService(GoogleApiSettings.Builder.WithApiKey("testkey").Build());
            var action = new Func<Task>(async () => await service.GetDetailsAsync(input, service.GetSessionToken()));
            action.Should()
                  .Throw<ArgumentNullException>()
                  .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: placeId");
        }

    }
}

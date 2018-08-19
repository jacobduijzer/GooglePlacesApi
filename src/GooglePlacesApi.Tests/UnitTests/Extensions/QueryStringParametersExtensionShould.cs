using FluentAssertions;
using GooglePlacesApi.Extensions;
using GooglePlacesApi.Models;
using Xunit;

namespace GooglePlacesApi.Tests.UnitTests.Extensions
{
    public class QueryStringParametersExtensionShould
    {
        [Fact]
        public void ReturnParamsWithApiKey()
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey("test")
                                            .Build();

            var queryParams = settings.CreateQueryStringParameters();

            queryParams.Should()
                       .BeOfType<GoogleApiQueryStringParameters>();

            queryParams.ApiKey
                       .Should()
                       .Be("test");
        }

        [Fact]
        public void ReturnParamsWithLanguage()
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey("test")
                                            .WithLanguage("nl")
                                            .Build();

            var queryParams = settings.CreateQueryStringParameters();

            queryParams.Language
                       .Should()
                       .Be("nl");
        }

        [Fact]
        public void ReturnParamsWithOneCountry()
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey("test")
                                            .WithLanguage("nl")
                                            .AddCountry("nl")
                                            .Build();

            var queryParams = settings.CreateQueryStringParameters();

            queryParams.Country
                       .Should()
                       .Be("country:nl");
        }

        [Fact]
        public void ReturnParamsWithMultipleCountries()
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey("test")
                                            .WithLanguage("nl")
                                            .AddCountry("nl")
                                            .AddCountry("de")
                                            .AddCountry("be")
                                            .Build();

            var queryParams = settings.CreateQueryStringParameters();

            queryParams.Country
                       .Should()
                       .Be("country:nl|country:de|country:be");
        }

        [Theory]
        [InlineData(PlaceTypes.Address, "address")]
        [InlineData(PlaceTypes.Cities, "(cities)")]
        [InlineData(PlaceTypes.Establishment, "establishment")]
        [InlineData(PlaceTypes.GeoCode, "geocode")]
        [InlineData(PlaceTypes.Regions, "(regions)")]
        public void ReturnCorrectType(PlaceTypes type, string expectedResult)
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey("test")
                                            .WithType(type)
                                            .Build();

            var queryParams = settings.CreateQueryStringParameters();

            queryParams.PlaceType
                       .Should()
                       .Be(expectedResult);
        }
    }
}

using System;
using FluentAssertions;
using GooglePlacesApi.Abstractions.Models;
using Xunit;
using GooglePlacesApi.Loggers;
using GooglePlacesApi.Abstractions.Models.GoogleApi;

namespace GooglePlacesApi.Tests.UnitTests.Models
{
    public class SettingsShould
    {
        [Fact]
        public void Construct()
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey("testkey")
                                            .Build();
            settings.Should()
                    .BeOfType<GoogleApiSettings>();

            settings.ApiKey
                    .Should()
                    .Be("testkey");
        }

        [Fact]
        public void ConstructWithLanguage()
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey("testkey")
                                            .WithLanguage("nl")
                                            .Build();
            settings.ApiKey
                    .Should()
                    .Be("testkey");
            
            settings.Language
                    .Should()
                    .Be("nl");
        }

        [Fact]
        public void ConstructWithCountry()
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey("testkey")
                                            .AddCountry("nl")
                                            .Build();
            
            settings.Countries
                    .Should()
                    .NotBeNullOrEmpty()
                    .And
                    .HaveCount(1)
                    .And
                    .Contain("nl");
        }

        [Fact]
        public void ConstructWithTypes()
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey("testkey")
                                            .WithType(PlaceTypes.GeoCode)
                                            .Build();
            settings.ApiKey
                    .Should()
                    .Be("testkey");
            
            settings.PlaceType
                    .Should()
                    .Be(PlaceTypes.GeoCode);
        }

        [Fact]
        public void ConstructWithLanguageAndTypes()
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey("testkey")
                                            .WithLanguage("nl")
                                            .WithType(PlaceTypes.GeoCode)
                                            .Build();
            settings.ApiKey
                    .Should()
                    .Be("testkey");
            
            settings.Language
                    .Should()
                    .Be("nl");

            settings.PlaceType
                    .Should()
                    .Be(PlaceTypes.GeoCode);
        }

        [Fact]
        public void ConstructWithLogging()
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey("testkey")
                                            .WithLanguage("nl")
                                            .WithType(PlaceTypes.GeoCode)
                                            .WithLogger(new ConsoleLogger())
                                            .Build();

            settings.Logger
                    .Should()
                    .NotBeNull()
                    .And
                    .BeOfType<ConsoleLogger>();
        }

        [Fact]
        public void ThrowWhenApiKeyIsNotSet()
        {
            var action = new Action(() => GoogleApiSettings.Builder.Build());

            action.Should()
                  .Throw<InvalidOperationException>()
                  .WithMessage("Set an api key first");
        }
    }
}

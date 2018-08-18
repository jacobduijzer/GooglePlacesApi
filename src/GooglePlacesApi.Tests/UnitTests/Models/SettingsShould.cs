using System;
using FluentAssertions;
using GooglePlacesApi.Abstractions.Models;
using Xunit;
using GooglePlacesApi.Loggers;

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

            settings.Language
                    .Should()
                    .Be(Constants.DEFAULT_LANGUAGE);

            settings.Countries
                    .Should()
                    .NotBeNullOrEmpty()
                    .And
                    .HaveCount(1)
                    .And
                    .Contain(Constants.DEFAULT_COUNTRY);
        }

        [Fact]
        public void ConstructWithLanguage()
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey("testkey")
                                            .WithLanguage("nl")
                                            .Build();

            settings.Language
                    .Should()
                    .Be("nl");
            
            settings.ApiKey
                    .Should()
                    .Be("testkey");
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
                                            .WithTypes("regions")
                                            .Build();
            settings.Types
                    .Should()
                    .Be("regions");

            settings.ApiKey
                    .Should()
                    .Be("testkey");

            settings.Language
                    .Should()
                    .Be(Constants.DEFAULT_LANGUAGE);
        }

        [Fact]
        public void ConstructWithLanguageAndTypes()
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey("testkey")
                                            .WithLanguage("nl")
                                            .WithTypes("regions")
                                            .Build();

            settings.Language
                    .Should()
                    .Be("nl");

            settings.Types
                    .Should()
                    .Be("regions");

            settings.ApiKey
                    .Should()
                    .Be("testkey");
        }

        [Fact]
        public void ConstructWithLogging()
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey("testkey")
                                            .WithLanguage("nl")
                                            .WithTypes("regions")
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

        [Fact]
        public void GenerateQueryString()
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey("testkey")
                                            .WithLanguage("nl")
                                            .WithTypes("regions")
                                            .Build();
            //settings.GetApiQueryString()
                    //.Should()
                    //.Be("Key=testkey&language=nl&components=country:nl&types=(regions)");

            //key ={ apiKey}
            //&language = nl & components = country:nl | country:be & types = (regions) &


        }
    }
}

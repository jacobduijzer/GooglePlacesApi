using System;
using System.Threading.Tasks;
using FluentAssertions;
using GooglePlacesApi.Abstractions.Models;
using GooglePlacesApi.Tests.Helpers;
using Xunit.Abstractions;
using GooglePlacesApi.Abstractions.Interfaces;
using GooglePlacesApi.Abstractions.Models.GoogleApi;

namespace GooglePlacesApi.Tests.IntegrationTests
{
    public class GoogleApiServiceShould
    {
        private readonly IRefitLogger _refitLogger;

        public GoogleApiServiceShould(ITestOutputHelper output)
        => _refitLogger = new TestLogger(output);

        [IntegrationTestOnlyFact]
        public async Task GetResults()
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey(Environment.GetEnvironmentVariable("GOOGLE_PLACES_API_KEY"))
                                            .WithLogger(_refitLogger)
                                            .WithType(PlaceTypes.GeoCode)
                                            .Build();

            var service = new GooglePlacesApiService(settings);

            var result = await service.GetPredictionsAsync("new y")
                                      .ConfigureAwait(false);

            result.Should()
                  .NotBeNull();

            result.Status
                  .Should()
                  .Be("OK");

            result.Items
                  .Should()
                  .NotBeNullOrEmpty();
        }
    }
}
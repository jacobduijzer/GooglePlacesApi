using System;
using System.Threading.Tasks;
using FluentAssertions;
using GooglePlacesApi.Interfaces;
using GooglePlacesApi.Models;
using GooglePlacesApi.Tests.Helpers;
using Xunit.Abstractions;
using System.Linq;

namespace GooglePlacesApi.Tests.IntegrationTests
{
    public class GoogleApiServiceShould
    {
        private readonly IRefitLogger _refitLogger;

        public GoogleApiServiceShould(ITestOutputHelper output)
        => _refitLogger = new TestLogger(output);

        [IntegrationTestOnlyFact]
        public async Task GetPredictionsAsync()
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

        [IntegrationTestOnlyFact]
        public async Task GetDetailsAsync()
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey(Environment.GetEnvironmentVariable("GOOGLE_PLACES_API_KEY"))
                                            .WithLogger(_refitLogger)
                                            .WithType(PlaceTypes.GeoCode)
                                            .Build();

            var service = new GooglePlacesApiService(settings);

            var predictions = await service.GetPredictionsAsync("new y")
                                           .ConfigureAwait(false);

            var details = await service.GetDetailsAsync(predictions.Items.FirstOrDefault().PlaceId, service.GetSessionToken())
                                       .ConfigureAwait(false);

            details.Should()
                   .NotBeNull();

            details.Place
                   .Should()
                   .NotBeNull();
        }
    }
}
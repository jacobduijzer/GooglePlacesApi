using System;
using System.Threading.Tasks;
using FluentAssertions;
using GooglePlacesApi.Abstractions.Models;
using GooglePlacesApi.Tests.Helpers;
using Xunit.Abstractions;
using GooglePlacesApi.Abstractions.Interfaces;

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
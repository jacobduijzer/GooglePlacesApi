using System;
using System.Threading.Tasks;
using GooglePlacesApi.Models;

namespace GooglePlacesApi.TestConsole
{
    class Program
    {
        protected static async Task Main(string[] args)
        {
            var settings = GoogleApiSettings.Builder
                                            .WithApiKey(Environment.GetEnvironmentVariable("GOOGLE_PLACES_API_KEY"))
                                            .WithType(PlaceTypes.GeoCode)
                                            .Build();

            var service = new GooglePlacesApiService(settings);

            var result = await service.GetPredictionsAsync("new y")
                                      .ConfigureAwait(false);

            if(result != null && result.Status.Equals("OK") && result.Items != null)
            {
                foreach(var item in result.Items)
                {
                    Console.WriteLine(item.Description);
                }
            }
        }
    }
}

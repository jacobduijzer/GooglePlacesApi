using System;
using System.Linq;
using System.Threading.Tasks;

namespace GooglePlacesApi.TestConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var settings = GooglePlacesApi.Models.GoogleApiSettings.Builder
                                          .WithApiKey(Environment.GetEnvironmentVariable("GOOGLE_PLACES_API_KEY"))
                                          .WithType(GooglePlacesApi.Models.PlaceTypes.GeoCode)
                                          .Build();

            var service = new GooglePlacesApiService(settings);

            var result = await service.GetPredictionsAsync("new y")
                                      .ConfigureAwait(false);

            if(result != null && result.Status.Equals("OK") && result.Items != null)
            {
                //foreach(var item in result.Items)
                //{
                //    Console.WriteLine("=========== PREDICTION ===========");
                //    Console.WriteLine(item.Description);

                //    var details = await service.GetDetailsAsync(item.PlaceId)
                //                               .ConfigureAwait(false);

                //    if(details != null)
                //    {
                //        Console.WriteLine("=========== DETAILS ===========");
                //        Console.WriteLine($"Id: {details.Place.Id}");
                //        Console.WriteLine($"PlaceId: {details.Place.PlaceId}");
                //        Console.WriteLine($"FormattedAddress: {details.Place.FormattedAddress}");
                //        Console.WriteLine($"Icon: {details.Place.Icon}");
                //        Console.WriteLine($"Icon: {details.Place.Reference}");
                //    }
                //}

                var item = result.Items.FirstOrDefault();

                Console.WriteLine("=========== PREDICTION ===========");
                Console.WriteLine(item.Description);


                var details = await service.GetDetailsAsync(item.PlaceId, service.GetSessionToken())
                                      .ConfigureAwait(false);

                if (details != null)
                {
                    Console.WriteLine("=========== DETAILS ===========");
                    Console.WriteLine($"Id: {details.Place.Id}");
                    Console.WriteLine($"PlaceId: {details.Place.PlaceId}");
                    Console.WriteLine($"FormattedAddress: {details.Place.FormattedAddress}");
                    Console.WriteLine($"Icon: {details.Place.Icon}");
                    Console.WriteLine($"Icon: {details.Place.Reference}");
                }
            }
        }
    }
}

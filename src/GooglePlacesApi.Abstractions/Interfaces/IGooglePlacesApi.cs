using System.Threading.Tasks;
using GooglePlacesApi.Models;
using Refit;

namespace GooglePlacesApi.Interfaces
{
    public interface IGooglePlacesApi
    {
        [Get("/maps/api/place/autocomplete/json?input={input}")]
        Task<Predictions> GetAutocompleteAsync(string input, GoogleApiQueryStringParameters queryStringParameters);

        [Get("/maps/api/place/details/json?key={apiKey}&placeid={placeId}")]
        Task<Details> GetDetailsAsync(string placeId, string apiKey);
    }
}

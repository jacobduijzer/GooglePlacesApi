using System.IO;
using System.Threading.Tasks;
using GooglePlacesApi.Models;
using Refit;

namespace GooglePlacesApi.Interfaces
{
    public interface IGooglePlacesApi
    {
        [Get("/maps/api/place/autocomplete/json?input={input}")]
        Task<Predictions> GetAutocompleteAsync(string input, GoogleApiQueryStringParameters queryStringParameters);

        [Get("/maps/api/place/details/json?key={apiKey}&placeid={placeId}&fields={fields}")]
        Task<Details> GetDetailsAsync(string apiKey, string placeId, string sessionToken, string fields);

        [Get("/maps/api/place/photo?maxwidth={maxWidth}&maxheight={maxHeight}&photoreference={photoReference}&key={apiKey}")]
        Task<Stream> GetPhotoAsync(string apiKey, string photoReference, int maxWidth, int maxHeight);
    }
}

using System.IO;
using System.Threading.Tasks;
using GooglePlacesApi.Models;

namespace GooglePlacesApi.Interfaces
{
    public interface IGooglePlacesApiService
    {
        Task<Predictions> GetPredictionsAsync(string searchText);

        Task<Details> GetDetailsAsync(string placeId, string sessionToken, DetailLevel detailLevel = DetailLevel.Basic);

        Task<Stream> GetPhotoAsync(string photoReference);

        string GetSessionToken();

        void ResetSessionToken();
    }
}

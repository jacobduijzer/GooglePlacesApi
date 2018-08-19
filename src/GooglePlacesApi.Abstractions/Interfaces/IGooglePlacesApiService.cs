using System.Threading.Tasks;
using GooglePlacesApi.Models;

namespace GooglePlacesApi.Interfaces
{
    public interface IGooglePlacesApiService
    {
        Task<Predictions> GetPredictionsAsync(string searchText);

        Task<Details> GetDetailsAsync(string placeId);
    }
}

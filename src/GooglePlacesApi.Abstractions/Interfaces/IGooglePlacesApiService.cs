using System.Threading.Tasks;
using GooglePlacesApi.Abstractions.Models;

namespace GooglePlacesApi.Abstractions.Interfaces
{
    public interface IGooglePlacesApiService
    {
        Task<Predictions> GetPredictionsAsync();
    }
}

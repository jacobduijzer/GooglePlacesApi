using System.Collections.Generic;
using System.Linq;
using GooglePlacesApi.Models;
using StoreLocator.Extensions;
using StoreLocator.Models;

namespace StoreLocator.Repositories
{
    public class StoreRepository
    {
        private readonly List<Store> _stores;

        public StoreRepository()
        {
            _stores = new List<Store>
            {
                new Store("Store 1", "Amsterdam", 52.3546274, 4.828584),
                new Store("Store 2", "London", 51.5285582, -0.241679),
                new Store("Store 3", "New York", 40.6974034, -74.1197625),
                new Store("Store 4", "Beijing", 39.9385466, 116.1172841),
                new Store("Store 5", "Sidney", -33.8679058, 151.2012372),
                new Store("Store 6", "Cape Town", -33.9152209, 18.3758824)
            };    
        }

        public List<Store> GetAll() => _stores;

        public List<Store> GetSortedStores(Location location)
        => _stores.OrderBy(x => x.Distance(location.Latitude, location.Longitude))
                  .ToList();
    }
}


using StoreLocator.Extensions;

namespace StoreLocator.Models
{
    public class PresentableStore
    {
        public Store Store { get; }

        public double Distance { get; }

        public PresentableStore(Store store) 
        => Store = store;

        public PresentableStore(Store store, double latitude, double longitude) : this(store)
        => Distance = store.Distance(latitude, longitude);
    }
}

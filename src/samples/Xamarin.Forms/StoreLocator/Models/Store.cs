namespace StoreLocator.Models
{
    public readonly struct Store
    {
        public string Name { get; }

        public string City { get; }

        public double Latitude { get; }

        public double Longitude { get; }

        public Store(string name, string city, double latitude, double longitude)
        {
            Name = name;
            City = city;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}

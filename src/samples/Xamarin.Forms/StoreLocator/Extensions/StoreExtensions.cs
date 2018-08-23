using System;
using StoreLocator.Models;

namespace StoreLocator.Extensions
{
    public static class StoreExtensions
    {
        public static double Distance(this Store store, double lat, double lng)
        {
            double dDistance = Double.MinValue;
            double dLat1InRad = store.Latitude * (Math.PI / 180.0);
            double dLong1InRad = store.Longitude * (Math.PI / 180.0);

            double dLat2InRad = lat * (Math.PI / 180.0);
            double dLong2InRad = lng * (Math.PI / 180.0);

            double dLongitude = dLong2InRad - dLong1InRad;
            double dLatitude = dLat2InRad - dLat1InRad;

            // Intermediate result a.
            double a = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) +
                       Math.Cos(dLat1InRad) * Math.Cos(dLat2InRad) *
                       Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

            // Intermediate result c (great circle distance in Radians).
            double c = 2.0 * Math.Asin(Math.Sqrt(a));

            // Distance.
            // const Double kEarthRadiusMiles = 3956.0;
            const Double kEarthRadiusKms = 6376.5;
            dDistance = kEarthRadiusKms * c;

            return dDistance;
        }
    }
}

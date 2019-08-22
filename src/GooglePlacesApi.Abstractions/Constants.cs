namespace GooglePlacesApi
{
    public static class Constants
    {
        public const string BASE_API_URL = "https://maps.googleapis.com";

        public const string REQUEST_FIELDS_BASIC = "id,place_id,name,geometry,formatted_address,reference,icon,address_components,adr_address,types,photos,plus_code,scope,url,utc_offset,vicinity,permanently_closed";

        public const string REQUEST_FIELDS_CONTACT = "formatted_phone_number,international_phone_number,opening_hours,website";

        public const string REQUEST_FIELDS_ATMOSPHERE = "price_level,rating,review,user_ratings_total";
    }
}

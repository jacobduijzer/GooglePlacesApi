using System;
using System.Collections.Generic;
using GooglePlacesApi.Abstractions.Interfaces;
using GooglePlacesApi.Abstractions.Models.GoogleApi;

namespace GooglePlacesApi.Abstractions.Models
{
    public class GoogleApiSettings
    {
        public string ApiKey { get; private set; }

        public string Language { get; private set; }

        public PlaceTypes PlaceType { get; private set; }

        public List<string> Countries { get; private set; }

        public IRefitLogger Logger { get; private set; }

        private GoogleApiSettings()
        {
        }

        #region Builder

        public static SettingsBuilder Builder => new SettingsBuilder();

        public class SettingsBuilder
        {
            private string _apiKey;
            private string _language;
            private PlaceTypes _type;
            private List<string> _countries = new List<string>();
            private IRefitLogger _logger;

            public SettingsBuilder WithApiKey(string apiKey)
            {
                if (string.IsNullOrEmpty(apiKey))
                    throw new ArgumentNullException(nameof(apiKey));

                _apiKey = apiKey;
                return this;
            }

            public SettingsBuilder WithLanguage(string language)
            {
                if (string.IsNullOrEmpty(language))
                    throw new ArgumentNullException(nameof(language));

                _language = language;
                return this;
            }

            public SettingsBuilder WithType(PlaceTypes type)
            {
                _type = type;
                return this;
            }


            public SettingsBuilder AddCountry(string country)
            {
                if (string.IsNullOrEmpty(country))
                    throw new ArgumentNullException(nameof(country));

                if (_countries.Count == 5)
                    throw new InvalidOperationException("You can not add more than 5 countries.");

                _countries.Add(country);
                return this;
            }

            public SettingsBuilder WithLogger(IRefitLogger logger)
            {
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
                return this;
            }

            public GoogleApiSettings Build()
            {
                if (string.IsNullOrEmpty(_apiKey))
                    throw new InvalidOperationException("Set an api key first");

                return new GoogleApiSettings
                {
                    ApiKey = _apiKey,
                    Language = _language,
                    PlaceType = _type,
                    Countries = _countries,
                    Logger = _logger
                };
            }
        }

        #endregion
    }
}

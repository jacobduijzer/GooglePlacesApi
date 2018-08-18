using System;
using System.Collections.Generic;
using System.Linq;
using GooglePlacesApi.Abstractions.Interfaces;

namespace GooglePlacesApi.Abstractions.Models
{
    public class GoogleApiSettings
    {
        public string ApiKey { get; private set; }

        public string Language { get; private set; }

        public string Types { get; private set; }

        public List<string> Countries { get; private set; }

        public IRefitLogger Logger { get; private set; }

        private GoogleApiSettings()
        {
        }

        public static SettingsBuilder Builder => new SettingsBuilder();

        public class SettingsBuilder
        {
            private string _apiKey;
            private string _language;
            private string _types; // find out what this does
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

            public SettingsBuilder WithTypes(string types)
            {
                if (string.IsNullOrEmpty(types))
                    throw new ArgumentNullException(nameof(types));

                _types = types;
                return this;
            }


            public SettingsBuilder AddCountry(string country)
            {
                if (string.IsNullOrEmpty(country))
                    throw new ArgumentNullException(nameof(country));

                _countries.Add(country);
                return this;
            }

            public SettingsBuilder WithLogger(IRefitLogger logger)
            {
                _logger = logger;
                return this;
            }

            public GoogleApiSettings Build()
            {
                if (string.IsNullOrEmpty(_apiKey))
                    throw new InvalidOperationException("Set an api key first");

                if (!_countries.Any())
                    _countries.Add(Constants.DEFAULT_COUNTRY);

                return new GoogleApiSettings
                {
                    ApiKey = _apiKey,
                    Language = !string.IsNullOrEmpty(_language) ? _language : Constants.DEFAULT_LANGUAGE,
                    Types = _types,
                    Countries = _countries,
                    Logger = _logger
                };
            }
        }
    }
}

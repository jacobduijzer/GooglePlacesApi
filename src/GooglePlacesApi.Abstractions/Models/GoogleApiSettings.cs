using System;
using System.Collections.Generic;
using System.Linq;
using GooglePlacesApi.Interfaces;

namespace GooglePlacesApi.Models
{
    public class GoogleApiSettings
    {
        public string ApiKey { get; private set; }

        public string Language { get; private set; }

        public PlaceTypes PlaceType { get; private set; }

        public List<string> Countries { get; private set; }

        public IRefitLogger Logger { get; private set; }

        public DetailLevel DetailLevel { get; private set; }

        public string SessionToken { get; set; } 

        public int Offset { get; private set; }

        public string Origin { get; private set; }

        public string Location { get; private set; }

        public int Radius { get; private set; }

        public bool StrictBounds { get; private set; } = false;

        private GoogleApiSettings()
        {
        }

        #region Builder

        public static SettingsBuilder Builder => new SettingsBuilder();

        public class SettingsBuilder
        {
            private string _apiKey;
            private string _language;
            private string _sessionToken;
            private int _offset;
            private string _origin;
            private string _location;
            private int _radius;
            private bool _strictBounds;
            private PlaceTypes _type;
            private DetailLevel _detailLevel;
            private readonly List<string> _countries = new List<string>();
            private IRefitLogger _logger;

            public SettingsBuilder WithApiKey(string apiKey)
            {
                if (string.IsNullOrWhiteSpace(apiKey))
                    throw new ArgumentNullException(nameof(apiKey));

                _apiKey = apiKey;
                return this;
            }

            public SettingsBuilder WithLanguage(string language)
            {
                if (string.IsNullOrWhiteSpace(language))
                    throw new ArgumentNullException(nameof(language));

                _language = language.Trim();
                return this;
            }

            public SettingsBuilder WithType(PlaceTypes type)
            {
                _type = type;
                return this;
            }
            public SettingsBuilder WithDetailLevel(DetailLevel detailLevel)
            {
                _detailLevel = detailLevel;
                return this;
            }

            public SettingsBuilder WithSessionToken(string sessionToken)
            {
                _sessionToken = sessionToken;
                return this;
            }

            public SettingsBuilder WithOffset(int offset)
            {
                _offset = offset;
                return this;
            }

            public SettingsBuilder WithOrigin(string origin)
            {
                _origin = origin;
                return this;
            }

            public SettingsBuilder WithLocation(string location)
            {
                _location = location;
                return this;
            }

            public SettingsBuilder WithRadius(int radius)
            {
                _radius = radius;
                return this;
            }

            public SettingsBuilder WithStrictBounds(bool strictBounds)
            {
                _strictBounds = strictBounds;
                return this;
            }

            public SettingsBuilder AddCountry(string country)
            {
                if (string.IsNullOrWhiteSpace(country))
                    throw new ArgumentNullException(nameof(country));

                if (_countries.Count == 5)
                    throw new InvalidOperationException("You can not add more than 5 countries.");

                if(_countries.Any(x => x.Equals(country)))
                    throw new InvalidOperationException("This country already exists.");
                
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
                if (string.IsNullOrWhiteSpace(_apiKey))
                    throw new InvalidOperationException("Set an api key first");

                return new GoogleApiSettings
                {
                    ApiKey = _apiKey,
                    Language = _language,
                    PlaceType = _type,
                    Countries = _countries,
                    Logger = _logger,
                    DetailLevel = _detailLevel,
                    SessionToken = _sessionToken,
                    Offset = _offset,
                    Origin = _origin,
                    Location = _location,
                    Radius = _radius,
                    StrictBounds = _strictBounds
                };
            }
        }

        #endregion
    }
}

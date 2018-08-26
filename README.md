[![Build status](https://ci.appveyor.com/api/projects/status/o8vur836rgftafau/branch/master?svg=true)](https://ci.appveyor.com/project/jacobduijzer/googleplacesapi-exe2x/branch/master) [![Nuget status](https://buildstats.info/nuget/GooglePlacesApi?includePreReleases=true)](https://www.nuget.org/packages/GooglePlacesApi/)

# GooglePlacesApi

This plugin makes it very easy to use the Google Places API. Please read my blog for the nitty-gritty details.

# Usage

The Google Places API needs to be enabled in the [developer console](https://console.cloud.google.com/) and also needs a valid paying account although it can be used without payments, depending of the level of details requested. Read more about billing [here](https://developers.google.com/places/web-service/usage-and-billing). 


1. Create a settings object:

```
var settings = GoogleApiSettings.Builder
                                            .WithApiKey("api_key")
                                            .WithLanguage("nl")
                                            .WithType(PlaceTypes.Address)
                                            .WithLogger(new ConsoleLogger())
                                            .AddCountry("nl")
                                            .Build();
```

2. Create a service:

```
var service = new GooglePlacesApiService(settings);
```

3. Get predictions:

```
var result = await service.GetPredictionsAsync("new y").ConfigureAwait(false);
```

4. Get details:

```
var details = await service.GetDetailsAsync("ChIJOwg_06VPwokRYv534QaPC8g")
                                      .ConfigureAwait(false);
```

# Privacy Policy & Terms

Please read the [Google Privact & Terms](https://policies.google.com/terms?hl=en) and [Privacy Policy](https://policies.google.com/privacy) when you want to use this plugin!
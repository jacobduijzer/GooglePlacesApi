[![Build status](https://ci.appveyor.com/api/projects/status/o8vur836rgftafau/branch/master?svg=true)](https://ci.appveyor.com/project/jacobduijzer/googleplacesapi-exe2x/branch/master) [![Nuget status](https://buildstats.info/nuget/GooglePlacesApi?includePreReleases=true)](https://www.nuget.org/packages/GooglePlacesApi/) [![CodeFactor](https://www.codefactor.io/repository/github/jacobduijzer/googleplacesapi/badge)](https://www.codefactor.io/repository/github/jacobduijzer/googleplacesapi) [![BuitlWithDot.Net shield](https://builtwithdot.net/project/82/googleplacesapi/badge)](https://builtwithdot.net/project/82/googleplacesapi)

# GooglePlacesApi

This plugin makes it very easy to use the Google Places API. Please read Jacob Duijzer's [blog](https://blog.duijzer.com/posts/google-places-api/) for the nitty-gritty details.

# Usage

The Google Places API needs to be enabled in the [developer console](https://console.cloud.google.com/) and also needs a valid paying account although it can be used without payments, depending of the level of details requested. Read more about billing [here](https://developers.google.com/places/web-service/usage-and-billing). 


1. Create a settings object:

```
var settings = GoogleApiSettings.Builder
                                            .WithApiKey("api_key")
                                            .WithLanguage("nl")
                                            .WithType(PlaceTypes.Address)
                                            .WithLogger(new ConsoleLogger())
					    .WithDetailLevel(DetailLevel.Basic)
					    .WithSessionToken("YOUR SESSION TOKEN")
                                            .WithOrigin("lat,lon")
					    .WithLocation("lat,lon")
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

4. Get details (you can also add a new session token in argument 2, if argument 3 is not given DetailLevel.Basic is used):

```
var details = await service.GetDetailsAsync("ChIJOwg_06VPwokRYv534QaPC8g", GetSessionToken(), DetailLevel.Full)
                                      .ConfigureAwait(false);
```
5. Get photos:

```
Stream photoStream = await _api.GetPhotoAsync("CnRtAAAATLZNl354RwP_9UKbQ_5Psy40texXePv4oAlgP4qNEkdIrkyse7rPXYGd9D_Uj1rVsQdWT4oRz4QrYAJNpFX7rzqqMlZw2h2E2y5IKMUZ7ouD_SlcHxYq1yL4KbKUv3qtWgTK0A6QbGh87GB3sscrHRIQiG2RrmU_jF4tENr9wGS_YxoUSSDrYjWmrNfeEHSGSc3FyhNLlBU")
									  .ConfigureAwait(false);
```
You can choose out of four detail levels, each [billed](https://developers.google.com/places/web-service/usage-and-billing) seperately by Google:  
a. DetailLevel.Basic  
b. DetailLevel.Contact (= Basic + Contact)  
c. DetailLevel.Atmosphere (= Basic + Atmosphere)  
d. DetailLevel.Full (= Basic + Contact + Atmosphere)  

# Privacy Policy & Terms

Please read the [Google Privacy & Terms](https://policies.google.com/terms?hl=en) and [Privacy Policy](https://policies.google.com/privacy) when you want to use this plugin!

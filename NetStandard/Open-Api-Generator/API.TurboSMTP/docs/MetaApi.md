# API.TurboSMTP.Api.MetaApi

All URIs are relative to *https://staging.api.serversmtp.com/api/v2*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetCountries**](MetaApi.md#getcountries) | **GET** /meta/countries | Get countries |
| [**GetStatesByCountry**](MetaApi.md#getstatesbycountry) | **GET** /meta/state/{isoCode} | Get states by country |

<a id="getcountries"></a>
# **GetCountries**
> List&lt;Country&gt; GetCountries ()

Get countries

Get countries 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class GetCountriesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://staging.api.serversmtp.com/api/v2";
            // Configure API key authorization: consumerSecret
            config.AddApiKey("consumerSecret", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("consumerSecret", "Bearer");
            // Configure API key authorization: ApiKeyAuth
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure API key authorization: consumerKey
            config.AddApiKey("consumerKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("consumerKey", "Bearer");

            var apiInstance = new MetaApi(config);

            try
            {
                // Get countries
                List<Country> result = apiInstance.GetCountries();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MetaApi.GetCountries: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetCountriesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get countries
    ApiResponse<List<Country>> response = apiInstance.GetCountriesWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MetaApi.GetCountriesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;Country&gt;**](Country.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Countries list |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getstatesbycountry"></a>
# **GetStatesByCountry**
> List&lt;State&gt; GetStatesByCountry (string isoCode)

Get states by country

Get states by country 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class GetStatesByCountryExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://staging.api.serversmtp.com/api/v2";
            // Configure API key authorization: consumerSecret
            config.AddApiKey("consumerSecret", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("consumerSecret", "Bearer");
            // Configure API key authorization: ApiKeyAuth
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure API key authorization: consumerKey
            config.AddApiKey("consumerKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("consumerKey", "Bearer");

            var apiInstance = new MetaApi(config);
            var isoCode = ES;  // string | Country ISO code

            try
            {
                // Get states by country
                List<State> result = apiInstance.GetStatesByCountry(isoCode);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MetaApi.GetStatesByCountry: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetStatesByCountryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get states by country
    ApiResponse<List<State>> response = apiInstance.GetStatesByCountryWithHttpInfo(isoCode);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MetaApi.GetStatesByCountryWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **isoCode** | **string** | Country ISO code |  |

### Return type

[**List&lt;State&gt;**](State.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | States selected |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |
| **404** | Not Found  Please verify the Country Iso Code Provided.  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


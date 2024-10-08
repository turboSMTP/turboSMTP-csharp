# API.TurboSMTP.Api.ConsumerkeyApi

All URIs are relative to *https://staging.api.serversmtp.com/api/v2*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateConsumerKey**](ConsumerkeyApi.md#createconsumerkey) | **POST** /user/consumerKeys | Create Consumer Key |
| [**DeleteConsumerKey**](ConsumerkeyApi.md#deleteconsumerkey) | **DELETE** /user/consumerKeys/{consumerKey} | Delete Consumer Key |
| [**ListConsumerKeys**](ConsumerkeyApi.md#listconsumerkeys) | **GET** /user/consumerKeys | Get Consumer Keys list |

<a id="createconsumerkey"></a>
# **CreateConsumerKey**
> ConsumerKeyCreateResponseBody CreateConsumerKey (ConsumerKeyCreateRequestBody consumerKeyCreateRequestBody)

Create Consumer Key

 Create new Consumer Key  Note: Consumer Key creation is not allwed when authenticated via Consumer Key. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class CreateConsumerKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://staging.api.serversmtp.com/api/v2";
            // Configure API key authorization: ApiKeyAuth
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ConsumerkeyApi(config);
            var consumerKeyCreateRequestBody = new ConsumerKeyCreateRequestBody(); // ConsumerKeyCreateRequestBody | 

            try
            {
                // Create Consumer Key
                ConsumerKeyCreateResponseBody result = apiInstance.CreateConsumerKey(consumerKeyCreateRequestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConsumerkeyApi.CreateConsumerKey: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateConsumerKeyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create Consumer Key
    ApiResponse<ConsumerKeyCreateResponseBody> response = apiInstance.CreateConsumerKeyWithHttpInfo(consumerKeyCreateRequestBody);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConsumerkeyApi.CreateConsumerKeyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **consumerKeyCreateRequestBody** | [**ConsumerKeyCreateRequestBody**](ConsumerKeyCreateRequestBody.md) |  |  |

### Return type

[**ConsumerKeyCreateResponseBody**](ConsumerKeyCreateResponseBody.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Sucess  Consumer Key Created Sucessfully.  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deleteconsumerkey"></a>
# **DeleteConsumerKey**
> CommonSuccessResponseBody DeleteConsumerKey (string consumerKey)

Delete Consumer Key

 Delete Consumer Key Note: Consumer Key deletion is not allwed when authenticated via Comsumer Key. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class DeleteConsumerKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://staging.api.serversmtp.com/api/v2";
            // Configure API key authorization: ApiKeyAuth
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ConsumerkeyApi(config);
            var consumerKey = b914ad238d0e8e8851b81e86ce46ae1d;  // string | Consumer Key

            try
            {
                // Delete Consumer Key
                CommonSuccessResponseBody result = apiInstance.DeleteConsumerKey(consumerKey);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConsumerkeyApi.DeleteConsumerKey: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteConsumerKeyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete Consumer Key
    ApiResponse<CommonSuccessResponseBody> response = apiInstance.DeleteConsumerKeyWithHttpInfo(consumerKey);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConsumerkeyApi.DeleteConsumerKeyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **consumerKey** | **string** | Consumer Key |  |

### Return type

[**CommonSuccessResponseBody**](CommonSuccessResponseBody.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  Consumer Key was deleted.  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |
| **404** | Not Found  Please verify the Consumer Key is valid.  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listconsumerkeys"></a>
# **ListConsumerKeys**
> ConsumerKeyListSucessResponsetBody ListConsumerKeys ()

Get Consumer Keys list

 Get Consumer Keys list  Note: Consumer Keys listing is not allwed when authenticated via Consumer Key. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class ListConsumerKeysExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://staging.api.serversmtp.com/api/v2";
            // Configure API key authorization: ApiKeyAuth
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ConsumerkeyApi(config);

            try
            {
                // Get Consumer Keys list
                ConsumerKeyListSucessResponsetBody result = apiInstance.ListConsumerKeys();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConsumerkeyApi.ListConsumerKeys: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListConsumerKeysWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get Consumer Keys list
    ApiResponse<ConsumerKeyListSucessResponsetBody> response = apiInstance.ListConsumerKeysWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConsumerkeyApi.ListConsumerKeysWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**ConsumerKeyListSucessResponsetBody**](ConsumerKeyListSucessResponsetBody.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  Consumer Keys list  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


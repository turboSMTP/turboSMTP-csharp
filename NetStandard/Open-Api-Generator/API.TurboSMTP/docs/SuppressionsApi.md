# API.TurboSMTP.Api.SuppressionsApi

All URIs are relative to *https://staging.api.serversmtp.com/api/v2*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**BulkDeleteSuppressions**](SuppressionsApi.md#bulkdeletesuppressions) | **POST** /suppressions/bulk_delete | Bulk delete suppressions |
| [**DeleteFilterSuppressions**](SuppressionsApi.md#deletefiltersuppressions) | **POST** /suppressions/delete | Delete suppressions |
| [**ExportFilterSuppressions**](SuppressionsApi.md#exportfiltersuppressions) | **POST** /suppressions/csv | Export filtered suppressions |
| [**ExportSuppressionsDataCSV**](SuppressionsApi.md#exportsuppressionsdatacsv) | **GET** /suppressions/csv | Export Suppressions data in CSV file |
| [**FilterSuppressions**](SuppressionsApi.md#filtersuppressions) | **POST** /suppressions | Filter suppressions |
| [**GetSuppressions**](SuppressionsApi.md#getsuppressions) | **GET** /suppressions | Get Suppressions Data |
| [**ImportSuppressions**](SuppressionsApi.md#importsuppressions) | **POST** /suppressions/import | Import Suppressions |

<a id="bulkdeletesuppressions"></a>
# **BulkDeleteSuppressions**
> SuppressionsDeleteSuccess BulkDeleteSuppressions (List<string> requestBody)

Bulk delete suppressions

Bulk delete suppressions 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class BulkDeleteSuppressionsExample
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

            var apiInstance = new SuppressionsApi(config);
            var requestBody = new List<string>(); // List<string> | 

            try
            {
                // Bulk delete suppressions
                SuppressionsDeleteSuccess result = apiInstance.BulkDeleteSuppressions(requestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SuppressionsApi.BulkDeleteSuppressions: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the BulkDeleteSuppressionsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Bulk delete suppressions
    ApiResponse<SuppressionsDeleteSuccess> response = apiInstance.BulkDeleteSuppressionsWithHttpInfo(requestBody);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SuppressionsApi.BulkDeleteSuppressionsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **requestBody** | [**List&lt;string&gt;**](string.md) |  |  |

### Return type

[**SuppressionsDeleteSuccess**](SuppressionsDeleteSuccess.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Suppressions were sucessfully deleted. |  -  |
| **400** | Bad Request  ###### Produces:  * no_contacts_were_provided  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deletefiltersuppressions"></a>
# **DeleteFilterSuppressions**
> SuppressionsDeleteSuccess DeleteFilterSuppressions (SuppressionFilterRequestBody suppressionFilterRequestBody)

Delete suppressions

Delete suppressions 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class DeleteFilterSuppressionsExample
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

            var apiInstance = new SuppressionsApi(config);
            var suppressionFilterRequestBody = new SuppressionFilterRequestBody(); // SuppressionFilterRequestBody | 

            try
            {
                // Delete suppressions
                SuppressionsDeleteSuccess result = apiInstance.DeleteFilterSuppressions(suppressionFilterRequestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SuppressionsApi.DeleteFilterSuppressions: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteFilterSuppressionsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete suppressions
    ApiResponse<SuppressionsDeleteSuccess> response = apiInstance.DeleteFilterSuppressionsWithHttpInfo(suppressionFilterRequestBody);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SuppressionsApi.DeleteFilterSuppressionsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **suppressionFilterRequestBody** | [**SuppressionFilterRequestBody**](SuppressionFilterRequestBody.md) |  |  |

### Return type

[**SuppressionsDeleteSuccess**](SuppressionsDeleteSuccess.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | deleted |  -  |
| **400** | Bad Request  ###### Produces:  *   |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exportfiltersuppressions"></a>
# **ExportFilterSuppressions**
> string ExportFilterSuppressions (SuppressionFilterRequestBody suppressionFilterRequestBody)

Export filtered suppressions

Export Filtered Suppressions 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class ExportFilterSuppressionsExample
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

            var apiInstance = new SuppressionsApi(config);
            var suppressionFilterRequestBody = new SuppressionFilterRequestBody(); // SuppressionFilterRequestBody | 

            try
            {
                // Export filtered suppressions
                string result = apiInstance.ExportFilterSuppressions(suppressionFilterRequestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SuppressionsApi.ExportFilterSuppressions: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ExportFilterSuppressionsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Export filtered suppressions
    ApiResponse<string> response = apiInstance.ExportFilterSuppressionsWithHttpInfo(suppressionFilterRequestBody);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SuppressionsApi.ExportFilterSuppressionsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **suppressionFilterRequestBody** | [**SuppressionFilterRequestBody**](SuppressionFilterRequestBody.md) |  |  |

### Return type

**string**

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: text/csv, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Suppressions CSV data |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exportsuppressionsdatacsv"></a>
# **ExportSuppressionsDataCSV**
> string ExportSuppressionsDataCSV (DateTime from, DateTime to, string tz = null, string filter = null, List<SuppressionSource> filterBy = null, bool? smartSearch = null, SuppressionOrderBy orderby = null, OrderType ordertype = null)

Export Suppressions data in CSV file

Export Suppressions data in CSV file 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class ExportSuppressionsDataCSVExample
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

            var apiInstance = new SuppressionsApi(config);
            var from = 2020-01-01;  // DateTime | Start date
            var to = 2025-12-31;  // DateTime | End date
            var tz = -07:00;  // string | Timezone Offset (optional) 
            var filter = Jhon.Doe@gmail.com;  // string | Text to search (recipient, sender, email subject or reason for suppression) (optional) 
            var filterBy = new List<SuppressionSource>(); // List<SuppressionSource> |  (optional) 
            var smartSearch = false;  // bool? | Smart search (optional)  (default to false)
            var orderby = new SuppressionOrderBy(); // SuppressionOrderBy |  (optional) 
            var ordertype = new OrderType(); // OrderType |  (optional) 

            try
            {
                // Export Suppressions data in CSV file
                string result = apiInstance.ExportSuppressionsDataCSV(from, to, tz, filter, filterBy, smartSearch, orderby, ordertype);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SuppressionsApi.ExportSuppressionsDataCSV: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ExportSuppressionsDataCSVWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Export Suppressions data in CSV file
    ApiResponse<string> response = apiInstance.ExportSuppressionsDataCSVWithHttpInfo(from, to, tz, filter, filterBy, smartSearch, orderby, ordertype);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SuppressionsApi.ExportSuppressionsDataCSVWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **from** | **DateTime** | Start date |  |
| **to** | **DateTime** | End date |  |
| **tz** | **string** | Timezone Offset | [optional]  |
| **filter** | **string** | Text to search (recipient, sender, email subject or reason for suppression) | [optional]  |
| **filterBy** | [**List&lt;SuppressionSource&gt;**](SuppressionSource.md) |  | [optional]  |
| **smartSearch** | **bool?** | Smart search | [optional] [default to false] |
| **orderby** | [**SuppressionOrderBy**](SuppressionOrderBy.md) |  | [optional]  |
| **ordertype** | [**OrderType**](OrderType.md) |  | [optional]  |

### Return type

**string**

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/csv, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Suppressions CSV data |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="filtersuppressions"></a>
# **FilterSuppressions**
> SuppressionsSucessResponsetBody FilterSuppressions (SuppressionFilterOrderPageRequestBody suppressionFilterOrderPageRequestBody)

Filter suppressions

Get Suppressions Data 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class FilterSuppressionsExample
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

            var apiInstance = new SuppressionsApi(config);
            var suppressionFilterOrderPageRequestBody = new SuppressionFilterOrderPageRequestBody(); // SuppressionFilterOrderPageRequestBody | 

            try
            {
                // Filter suppressions
                SuppressionsSucessResponsetBody result = apiInstance.FilterSuppressions(suppressionFilterOrderPageRequestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SuppressionsApi.FilterSuppressions: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the FilterSuppressionsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Filter suppressions
    ApiResponse<SuppressionsSucessResponsetBody> response = apiInstance.FilterSuppressionsWithHttpInfo(suppressionFilterOrderPageRequestBody);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SuppressionsApi.FilterSuppressionsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **suppressionFilterOrderPageRequestBody** | [**SuppressionFilterOrderPageRequestBody**](SuppressionFilterOrderPageRequestBody.md) |  |  |

### Return type

[**SuppressionsSucessResponsetBody**](SuppressionsSucessResponsetBody.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  Get Filtered Suppressions Data.  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getsuppressions"></a>
# **GetSuppressions**
> SuppressionsSucessResponsetBody GetSuppressions (DateTime from, DateTime to, int? page = null, int? limit = null, string tz = null, string filter = null, List<SuppressionSource> filterBy = null, bool? smartSearch = null, SuppressionOrderBy orderby = null, OrderType ordertype = null)

Get Suppressions Data

Get Suppressions Data 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class GetSuppressionsExample
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

            var apiInstance = new SuppressionsApi(config);
            var from = 2020-01-01;  // DateTime | Start date
            var to = 2025-12-31;  // DateTime | End date
            var page = 1;  // int? | Page number (optional)  (default to 1)
            var limit = 10;  // int? | The numbers of rows per page to return (optional)  (default to 10)
            var tz = -07:00;  // string | Timezone Offset (optional) 
            var filter = Jhon.Doe@gmail.com;  // string | Text to search (recipient, sender, email subject or reason for suppression) (optional) 
            var filterBy = new List<SuppressionSource>(); // List<SuppressionSource> |  (optional) 
            var smartSearch = false;  // bool? | Smart search (optional)  (default to false)
            var orderby = new SuppressionOrderBy(); // SuppressionOrderBy |  (optional) 
            var ordertype = new OrderType(); // OrderType |  (optional) 

            try
            {
                // Get Suppressions Data
                SuppressionsSucessResponsetBody result = apiInstance.GetSuppressions(from, to, page, limit, tz, filter, filterBy, smartSearch, orderby, ordertype);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SuppressionsApi.GetSuppressions: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetSuppressionsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get Suppressions Data
    ApiResponse<SuppressionsSucessResponsetBody> response = apiInstance.GetSuppressionsWithHttpInfo(from, to, page, limit, tz, filter, filterBy, smartSearch, orderby, ordertype);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SuppressionsApi.GetSuppressionsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **from** | **DateTime** | Start date |  |
| **to** | **DateTime** | End date |  |
| **page** | **int?** | Page number | [optional] [default to 1] |
| **limit** | **int?** | The numbers of rows per page to return | [optional] [default to 10] |
| **tz** | **string** | Timezone Offset | [optional]  |
| **filter** | **string** | Text to search (recipient, sender, email subject or reason for suppression) | [optional]  |
| **filterBy** | [**List&lt;SuppressionSource&gt;**](SuppressionSource.md) |  | [optional]  |
| **smartSearch** | **bool?** | Smart search | [optional] [default to false] |
| **orderby** | [**SuppressionOrderBy**](SuppressionOrderBy.md) |  | [optional]  |
| **ordertype** | [**OrderType**](OrderType.md) |  | [optional]  |

### Return type

[**SuppressionsSucessResponsetBody**](SuppressionsSucessResponsetBody.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  Get Filtered Suppressions Data.  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="importsuppressions"></a>
# **ImportSuppressions**
> SuppressionUploadResponse ImportSuppressions (SuppressionImportJson suppressionImportJson)

Import Suppressions

 Import Suppressions 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class ImportSuppressionsExample
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

            var apiInstance = new SuppressionsApi(config);
            var suppressionImportJson = new SuppressionImportJson(); // SuppressionImportJson | 

            try
            {
                // Import Suppressions
                SuppressionUploadResponse result = apiInstance.ImportSuppressions(suppressionImportJson);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SuppressionsApi.ImportSuppressions: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ImportSuppressionsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Import Suppressions
    ApiResponse<SuppressionUploadResponse> response = apiInstance.ImportSuppressionsWithHttpInfo(suppressionImportJson);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SuppressionsApi.ImportSuppressionsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **suppressionImportJson** | [**SuppressionImportJson**](SuppressionImportJson.md) |  |  |

### Return type

[**SuppressionUploadResponse**](SuppressionUploadResponse.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: application/json, multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  Email Addresses were imported.  |  -  |
| **400** | Bad Request  ###### Produces:  * missing_upload_file * invalid_mail_address_list  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


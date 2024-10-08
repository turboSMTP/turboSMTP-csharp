# API.TurboSMTP.Api.AnalyticsApi

All URIs are relative to *https://staging.api.serversmtp.com/api/v2*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ExportAnalyticsDataCSV**](AnalyticsApi.md#exportanalyticsdatacsv) | **GET** /analytics/csv | Export Analytics data in CSV file |
| [**GetAnalyticsData**](AnalyticsApi.md#getanalyticsdata) | **GET** /analytics | Get Analytics Data |
| [**GetAnalyticsDataByID**](AnalyticsApi.md#getanalyticsdatabyid) | **GET** /analytics/{Id} | Get Analytics Single Item by ID |

<a id="exportanalyticsdatacsv"></a>
# **ExportAnalyticsDataCSV**
> string ExportAnalyticsDataCSV (DateTime from, DateTime to, List<AnalyticMailStatus> status = null, List<AnalyticFilterByOption> filterBy = null, string filter = null, bool? smartSearch = null, AnalyticOrderBy orderby = null, OrderType ordertype = null, string tz = null)

Export Analytics data in CSV file

Export Analytics data in CSV file 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class ExportAnalyticsDataCSVExample
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

            var apiInstance = new AnalyticsApi(config);
            var from = 2020-01-01;  // DateTime | Start date
            var to = 2025-12-31;  // DateTime | End date
            var status = new List<AnalyticMailStatus>(); // List<AnalyticMailStatus> | Filter by Status      NEW: email has been queued for delivery     DEFER: email is in the queue for delivery     SUCCESS: email has been delivered.     OPEN: email has been opened.     CLICK: email has been clicked.     REPORT: email has been reported as spam.     FAIL: email has bounced.     SYSFAIL: email was dropped.     UNSUB: email is unsubscribed.  <br /> Notice that emails that fall into the above statuses can be grouped, ie Turbo-Smtp uses the following groups: <br />      'Clicks' = 'CLICK',     'Unsubscribes' = 'UNSUB',     'Spam' = 'REPORT',     'Drop' = 'SYSFAIL',     'Queued' = 'NEW' or 'DEFER',     'Opens'= 'OPEN' or 'CLICK' or 'UNSUB' or 'REPORT',     'Delivered'= 'SUCCESS'  or 'OPEN' or 'CLICK' or 'UNSUB' or 'REPORT',     'Bounce': 'FAIL'.    (optional) 
            var filterBy = new List<AnalyticFilterByOption>(); // List<AnalyticFilterByOption> | Filter by (optional) 
            var filter = September 2022;  // string | Text to search (recipient, sender, email subject or reason for suppression) (optional) 
            var smartSearch = false;  // bool? | Smart search (optional)  (default to false)
            var orderby = new AnalyticOrderBy(); // AnalyticOrderBy | Order by (optional) 
            var ordertype = new OrderType(); // OrderType |  (optional) 
            var tz = -07:00;  // string | Timezone Offset (optional) 

            try
            {
                // Export Analytics data in CSV file
                string result = apiInstance.ExportAnalyticsDataCSV(from, to, status, filterBy, filter, smartSearch, orderby, ordertype, tz);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AnalyticsApi.ExportAnalyticsDataCSV: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ExportAnalyticsDataCSVWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Export Analytics data in CSV file
    ApiResponse<string> response = apiInstance.ExportAnalyticsDataCSVWithHttpInfo(from, to, status, filterBy, filter, smartSearch, orderby, ordertype, tz);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AnalyticsApi.ExportAnalyticsDataCSVWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **from** | **DateTime** | Start date |  |
| **to** | **DateTime** | End date |  |
| **status** | [**List&lt;AnalyticMailStatus&gt;**](AnalyticMailStatus.md) | Filter by Status      NEW: email has been queued for delivery     DEFER: email is in the queue for delivery     SUCCESS: email has been delivered.     OPEN: email has been opened.     CLICK: email has been clicked.     REPORT: email has been reported as spam.     FAIL: email has bounced.     SYSFAIL: email was dropped.     UNSUB: email is unsubscribed.  &lt;br /&gt; Notice that emails that fall into the above statuses can be grouped, ie Turbo-Smtp uses the following groups: &lt;br /&gt;      &#39;Clicks&#39; &#x3D; &#39;CLICK&#39;,     &#39;Unsubscribes&#39; &#x3D; &#39;UNSUB&#39;,     &#39;Spam&#39; &#x3D; &#39;REPORT&#39;,     &#39;Drop&#39; &#x3D; &#39;SYSFAIL&#39;,     &#39;Queued&#39; &#x3D; &#39;NEW&#39; or &#39;DEFER&#39;,     &#39;Opens&#39;&#x3D; &#39;OPEN&#39; or &#39;CLICK&#39; or &#39;UNSUB&#39; or &#39;REPORT&#39;,     &#39;Delivered&#39;&#x3D; &#39;SUCCESS&#39;  or &#39;OPEN&#39; or &#39;CLICK&#39; or &#39;UNSUB&#39; or &#39;REPORT&#39;,     &#39;Bounce&#39;: &#39;FAIL&#39;.    | [optional]  |
| **filterBy** | [**List&lt;AnalyticFilterByOption&gt;**](AnalyticFilterByOption.md) | Filter by | [optional]  |
| **filter** | **string** | Text to search (recipient, sender, email subject or reason for suppression) | [optional]  |
| **smartSearch** | **bool?** | Smart search | [optional] [default to false] |
| **orderby** | [**AnalyticOrderBy**](AnalyticOrderBy.md) | Order by | [optional]  |
| **ordertype** | [**OrderType**](OrderType.md) |  | [optional]  |
| **tz** | **string** | Timezone Offset | [optional]  |

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
| **200** | Analytics CSV data |  -  |
| **400** | Bad Request  ###### Produces:  * missing_required_parameter_from * from_format_should_be_yyyy-mm-dd * missing_required_parameter_to * to_format_should_be_yyyy-mm-dd * missing_required_parameter_filter_by * invalid_status_value * filter_by_can_only_be_subject_or_sender_or_recipient_or_domain * smart_search_should_be_true_or_false * orderby_can_only_be_subject_or_sender_or_recipient_or_domain * ordertype_should_be_asc_or_desc                    |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getanalyticsdata"></a>
# **GetAnalyticsData**
> AnalyticsListSucessResponsetBody GetAnalyticsData (DateTime from, DateTime to, int? page = null, int? limit = null, List<AnalyticMailStatus> status = null, List<AnalyticFilterByOption> filterBy = null, string filter = null, bool? smartSearch = null, AnalyticOrderBy orderby = null, OrderType ordertype = null, string tz = null)

Get Analytics Data

Get Analytics Data 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class GetAnalyticsDataExample
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

            var apiInstance = new AnalyticsApi(config);
            var from = 2020-01-01;  // DateTime | Start date
            var to = 2025-12-31;  // DateTime | End date
            var page = 1;  // int? | Page number (optional)  (default to 1)
            var limit = 10;  // int? | The numbers of rows per page to return (optional)  (default to 10)
            var status = new List<AnalyticMailStatus>(); // List<AnalyticMailStatus> | Filter by Status      NEW: email has been queued for delivery     DEFER: email is in the queue for delivery     SUCCESS: email has been delivered.     OPEN: email has been opened.     CLICK: email has been clicked.     REPORT: email has been reported as spam.     FAIL: email has bounced.     SYSFAIL: email was dropped.     UNSUB: email is unsubscribed.  <br /> Notice that emails that fall into the above statuses can be grouped, ie Turbo-Smtp uses the following groups: <br />      'Clicks' = 'CLICK',     'Unsubscribes' = 'UNSUB',     'Spam' = 'REPORT',     'Drop' = 'SYSFAIL',     'Queued' = 'NEW' or 'DEFER',     'Opens'= 'OPEN' or 'CLICK' or 'UNSUB' or 'REPORT',     'Delivered'= 'SUCCESS'  or 'OPEN' or 'CLICK' or 'UNSUB' or 'REPORT',     'Bounce': 'FAIL'.    (optional) 
            var filterBy = new List<AnalyticFilterByOption>(); // List<AnalyticFilterByOption> | Filter by (optional) 
            var filter = September 2022;  // string | Text to search (recipient, sender, email subject or reason for suppression) (optional) 
            var smartSearch = false;  // bool? | Smart search (optional)  (default to false)
            var orderby = new AnalyticOrderBy(); // AnalyticOrderBy | Order by (optional) 
            var ordertype = new OrderType(); // OrderType |  (optional) 
            var tz = -07:00;  // string | Timezone Offset (optional) 

            try
            {
                // Get Analytics Data
                AnalyticsListSucessResponsetBody result = apiInstance.GetAnalyticsData(from, to, page, limit, status, filterBy, filter, smartSearch, orderby, ordertype, tz);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AnalyticsApi.GetAnalyticsData: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAnalyticsDataWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get Analytics Data
    ApiResponse<AnalyticsListSucessResponsetBody> response = apiInstance.GetAnalyticsDataWithHttpInfo(from, to, page, limit, status, filterBy, filter, smartSearch, orderby, ordertype, tz);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AnalyticsApi.GetAnalyticsDataWithHttpInfo: " + e.Message);
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
| **status** | [**List&lt;AnalyticMailStatus&gt;**](AnalyticMailStatus.md) | Filter by Status      NEW: email has been queued for delivery     DEFER: email is in the queue for delivery     SUCCESS: email has been delivered.     OPEN: email has been opened.     CLICK: email has been clicked.     REPORT: email has been reported as spam.     FAIL: email has bounced.     SYSFAIL: email was dropped.     UNSUB: email is unsubscribed.  &lt;br /&gt; Notice that emails that fall into the above statuses can be grouped, ie Turbo-Smtp uses the following groups: &lt;br /&gt;      &#39;Clicks&#39; &#x3D; &#39;CLICK&#39;,     &#39;Unsubscribes&#39; &#x3D; &#39;UNSUB&#39;,     &#39;Spam&#39; &#x3D; &#39;REPORT&#39;,     &#39;Drop&#39; &#x3D; &#39;SYSFAIL&#39;,     &#39;Queued&#39; &#x3D; &#39;NEW&#39; or &#39;DEFER&#39;,     &#39;Opens&#39;&#x3D; &#39;OPEN&#39; or &#39;CLICK&#39; or &#39;UNSUB&#39; or &#39;REPORT&#39;,     &#39;Delivered&#39;&#x3D; &#39;SUCCESS&#39;  or &#39;OPEN&#39; or &#39;CLICK&#39; or &#39;UNSUB&#39; or &#39;REPORT&#39;,     &#39;Bounce&#39;: &#39;FAIL&#39;.    | [optional]  |
| **filterBy** | [**List&lt;AnalyticFilterByOption&gt;**](AnalyticFilterByOption.md) | Filter by | [optional]  |
| **filter** | **string** | Text to search (recipient, sender, email subject or reason for suppression) | [optional]  |
| **smartSearch** | **bool?** | Smart search | [optional] [default to false] |
| **orderby** | [**AnalyticOrderBy**](AnalyticOrderBy.md) | Order by | [optional]  |
| **ordertype** | [**OrderType**](OrderType.md) |  | [optional]  |
| **tz** | **string** | Timezone Offset | [optional]  |

### Return type

[**AnalyticsListSucessResponsetBody**](AnalyticsListSucessResponsetBody.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  Get Analytics Data.  |  -  |
| **400** | Bad Request  ###### Produces:  * page_should_be_integer * page_should_be_greater_than_0 * limit_should_be_integer * limit_should_be_greater_than_0 * missing_required_parameter_from * from_format_should_be_yyyy-mm-dd * missing_required_parameter_to * to_format_should_be_yyyy-mm-dd * missing_required_parameter_filter_by * invalid_status_value * filter_by_can_only_be_subject_or_sender_or_recipient_or_domain * smart_search_should_be_true_or_false * orderby_can_only_be_subject_or_sender_or_recipient_or_domain * ordertype_should_be_asc_or_desc                    |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getanalyticsdatabyid"></a>
# **GetAnalyticsDataByID**
> AnalyticMailItem GetAnalyticsDataByID (int id)

Get Analytics Single Item by ID

Get Analytics Data by ID 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class GetAnalyticsDataByIDExample
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

            var apiInstance = new AnalyticsApi(config);
            var id = 56;  // int | Id

            try
            {
                // Get Analytics Single Item by ID
                AnalyticMailItem result = apiInstance.GetAnalyticsDataByID(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AnalyticsApi.GetAnalyticsDataByID: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAnalyticsDataByIDWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get Analytics Single Item by ID
    ApiResponse<AnalyticMailItem> response = apiInstance.GetAnalyticsDataByIDWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AnalyticsApi.GetAnalyticsDataByIDWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | Id |  |

### Return type

[**AnalyticMailItem**](AnalyticMailItem.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  Response body contains the Analytic Item requested by ID.  |  -  |
| **400** | Bad Request  ###### Produces:  * XXXXXXX  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |
| **404** | Not Found  The Analytic ID was not found  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


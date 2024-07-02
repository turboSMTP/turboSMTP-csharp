# API.TurboSMTP.Api.MailApi

All URIs are relative to *https://staging.api.serversmtp.com/api/v2*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**SendEmail**](MailApi.md#sendemail) | **POST** /mail/send | Send email message |

<a id="sendemail"></a>
# **SendEmail**
> SendSucessResponsetBody SendEmail (EmailRequestBody emailRequestBody)

Send email message

Send email message  ###### **Notes:** **- When using API Keys (suggested authentication method), authuser and authpass properties should not be included.**  **- Switch to \"Complete Email Send Request Body\" sample to learn about advanced features such as using attachments, custom headers like reply-to address, tracking and others.**  ###### Limitations:      * The total size of your email, including attachments, must be less than 24MB. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class SendEmailExample
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

            var apiInstance = new MailApi(config);
            var emailRequestBody = new EmailRequestBody(); // EmailRequestBody | 

            try
            {
                // Send email message
                SendSucessResponsetBody result = apiInstance.SendEmail(emailRequestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MailApi.SendEmail: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SendEmailWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Send email message
    ApiResponse<SendSucessResponsetBody> response = apiInstance.SendEmailWithHttpInfo(emailRequestBody);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MailApi.SendEmailWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **emailRequestBody** | [**EmailRequestBody**](EmailRequestBody.md) |  |  |

### Return type

[**SendSucessResponsetBody**](SendSucessResponsetBody.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  Turbo-SMTP successfully received your message.  |  -  |
| **400** | Bad Request  There was a problem processing the request due to an invalid/missing parameter for the request.  |  -  |
| **401** | Unauthorized  Missing or Invalid Turbo-SMTP credentials provided.  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


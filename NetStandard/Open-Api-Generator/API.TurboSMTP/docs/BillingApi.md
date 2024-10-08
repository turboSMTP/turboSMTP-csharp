# API.TurboSMTP.Api.BillingApi

All URIs are relative to *https://staging.api.serversmtp.com/api/v2*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**BuyEmailValidatorCredits**](BillingApi.md#buyemailvalidatorcredits) | **POST** /billing/buy_emailvalidation_credits | Buy Email Validator Credits |

<a id="buyemailvalidatorcredits"></a>
# **BuyEmailValidatorCredits**
> BuyEmailValidatorCreditsSucessResponse BuyEmailValidatorCredits (BuyEmailValidatorCreditsRequest buyEmailValidatorCreditsRequest)

Buy Email Validator Credits

 Buy Email Validator Credits 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class BuyEmailValidatorCreditsExample
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

            var apiInstance = new BillingApi(config);
            var buyEmailValidatorCreditsRequest = new BuyEmailValidatorCreditsRequest(); // BuyEmailValidatorCreditsRequest | 

            try
            {
                // Buy Email Validator Credits
                BuyEmailValidatorCreditsSucessResponse result = apiInstance.BuyEmailValidatorCredits(buyEmailValidatorCreditsRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BillingApi.BuyEmailValidatorCredits: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the BuyEmailValidatorCreditsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Buy Email Validator Credits
    ApiResponse<BuyEmailValidatorCreditsSucessResponse> response = apiInstance.BuyEmailValidatorCreditsWithHttpInfo(buyEmailValidatorCreditsRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BillingApi.BuyEmailValidatorCreditsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **buyEmailValidatorCreditsRequest** | [**BuyEmailValidatorCreditsRequest**](BuyEmailValidatorCreditsRequest.md) |  |  |

### Return type

[**BuyEmailValidatorCreditsSucessResponse**](BuyEmailValidatorCreditsSucessResponse.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  Returns url to the billing system to allow payment completition.   |  -  |
| **400** | Bad Request  ###### Produces:  * missing_required_parameter_amount * amount_should_be_integer * amount_should_not_be_less_than_15 * amount_should_not_be_higher_than_1800 * can_not_buy_extra_credit_without_active_plan  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


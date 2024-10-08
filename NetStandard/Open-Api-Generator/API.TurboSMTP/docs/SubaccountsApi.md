# API.TurboSMTP.Api.SubaccountsApi

All URIs are relative to *https://staging.api.serversmtp.com/api/v2*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CheckIfAccountEmailExists**](SubaccountsApi.md#checkifaccountemailexists) | **GET** /subaccounts/email-exists | Check if account email exists in turboSMTP |
| [**CreateSubaccount**](SubaccountsApi.md#createsubaccount) | **POST** /subaccounts | Create Subaccount. |
| [**DeleteLogoFile**](SubaccountsApi.md#deletelogofile) | **DELETE** /subaccounts/logo | Delete agency logo |
| [**GetActivePlan**](SubaccountsApi.md#getactiveplan) | **GET** /subaccounts/{Id}/active-plan | Get subaccount active plan. |
| [**GetAgencySettings**](SubaccountsApi.md#getagencysettings) | **GET** /subaccounts/agency | Update Agency details |
| [**GetLogoFile**](SubaccountsApi.md#getlogofile) | **GET** /subaccounts/logo | Get agency logo |
| [**GetSubaccountDetails**](SubaccountsApi.md#getsubaccountdetails) | **GET** /subaccounts/{Id} | Get sub account details |
| [**GetSubaccounts**](SubaccountsApi.md#getsubaccounts) | **GET** /subaccounts/list | Get Subaccounts lists information |
| [**SubaccountAuthenticationLogin**](SubaccountsApi.md#subaccountauthenticationlogin) | **POST** /subaccounts/authorize | Login to a subaccount |
| [**UpdateAgencySettings**](SubaccountsApi.md#updateagencysettings) | **PATCH** /subaccounts/agency | Update Agency details |
| [**UpdateSubaccountDetails**](SubaccountsApi.md#updatesubaccountdetails) | **PATCH** /subaccounts/{Id} | Update sub account details |
| [**UpdateSubaccountSMTPLimit**](SubaccountsApi.md#updatesubaccountsmtplimit) | **POST** /subaccounts/{Id}/updatesubaccountsmtplimit | Set subaccount smtp limit |
| [**UpdateSubaccountStatus**](SubaccountsApi.md#updatesubaccountstatus) | **POST** /subaccounts/{Id}/updatesubaccountstatus | Set subaccount status |
| [**UploadLogoFile**](SubaccountsApi.md#uploadlogofile) | **POST** /subaccounts/logo | Upload agency logo |

<a id="checkifaccountemailexists"></a>
# **CheckIfAccountEmailExists**
> CommmonResultResponseBody CheckIfAccountEmailExists (string email)

Check if account email exists in turboSMTP

 Check if account email exists in turboSMTP 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class CheckIfAccountEmailExistsExample
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

            var apiInstance = new SubaccountsApi(config);
            var email = username@gmail.com;  // string | Email address.

            try
            {
                // Check if account email exists in turboSMTP
                CommmonResultResponseBody result = apiInstance.CheckIfAccountEmailExists(email);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubaccountsApi.CheckIfAccountEmailExists: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CheckIfAccountEmailExistsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Check if account email exists in turboSMTP
    ApiResponse<CommmonResultResponseBody> response = apiInstance.CheckIfAccountEmailExistsWithHttpInfo(email);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SubaccountsApi.CheckIfAccountEmailExistsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **email** | **string** | Email address. |  |

### Return type

[**CommmonResultResponseBody**](CommmonResultResponseBody.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  Returns true if email address is already associated to a turboSMTP account.   |  -  |
| **400** | Bad Request  ###### Produces:  * missing_required_parameter_email  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |
| **403** | Forbidden  The current active plan does not include this feature, upgrade is required to use this feature.  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="createsubaccount"></a>
# **CreateSubaccount**
> Subaccount CreateSubaccount (SubaccountCreateRequest subaccountCreateRequest)

Create Subaccount.

 Create subaccount. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class CreateSubaccountExample
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

            var apiInstance = new SubaccountsApi(config);
            var subaccountCreateRequest = new SubaccountCreateRequest(); // SubaccountCreateRequest | 

            try
            {
                // Create Subaccount.
                Subaccount result = apiInstance.CreateSubaccount(subaccountCreateRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubaccountsApi.CreateSubaccount: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateSubaccountWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create Subaccount.
    ApiResponse<Subaccount> response = apiInstance.CreateSubaccountWithHttpInfo(subaccountCreateRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SubaccountsApi.CreateSubaccountWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **subaccountCreateRequest** | [**SubaccountCreateRequest**](SubaccountCreateRequest.md) |  |  |

### Return type

[**Subaccount**](Subaccount.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Sub account details. |  -  |
| **400** | Bad Request  ###### Produces:  * email_is_already_in_use * missing_required_parameter_email * missing_required_parameter_first_name * missing_required_parameter_last_name * missing_required_parameter_password * password_length_should_not_be_less_than_10_characters * password_should_contain_at_least_one_uppercase_character * password_should_contain_at_least_one_digit * missing_required_parameter_confirm_password * password_should_equal_confirm_password * missing_required_parameter_ip * ip_should_be_IPV4_format * ip_not_associated_to_user_account * policy_agree_should_be_true  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |
| **403** | Forbidden  The current active plan does not include this feature, upgrade is required to use this feature.  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deletelogofile"></a>
# **DeleteLogoFile**
> CommonSuccessResponseBody DeleteLogoFile ()

Delete agency logo

 Delete agency logo 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class DeleteLogoFileExample
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

            var apiInstance = new SubaccountsApi(config);

            try
            {
                // Delete agency logo
                CommonSuccessResponseBody result = apiInstance.DeleteLogoFile();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubaccountsApi.DeleteLogoFile: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteLogoFileWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete agency logo
    ApiResponse<CommonSuccessResponseBody> response = apiInstance.DeleteLogoFileWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SubaccountsApi.DeleteLogoFileWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**CommonSuccessResponseBody**](CommonSuccessResponseBody.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  Logo was deleted.  |  -  |
| **404** | Not Found  Agency Logo was not found.  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getactiveplan"></a>
# **GetActivePlan**
> SubaccountActivePlan GetActivePlan (int id)

Get subaccount active plan.

 Get subaccount active plan. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class GetActivePlanExample
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

            var apiInstance = new SubaccountsApi(config);
            var id = 56;  // int | Id

            try
            {
                // Get subaccount active plan.
                SubaccountActivePlan result = apiInstance.GetActivePlan(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubaccountsApi.GetActivePlan: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetActivePlanWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get subaccount active plan.
    ApiResponse<SubaccountActivePlan> response = apiInstance.GetActivePlanWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SubaccountsApi.GetActivePlanWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | Id |  |

### Return type

[**SubaccountActivePlan**](SubaccountActivePlan.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Login successfull |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |
| **403** | Forbidden  The current active plan does not include this feature, upgrade is required to use this feature.  |  -  |
| **404** | Not Found  Please verify the subaccount id is valid.  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getagencysettings"></a>
# **GetAgencySettings**
> AgencySettings GetAgencySettings ()

Update Agency details

 Get Agency details. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class GetAgencySettingsExample
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

            var apiInstance = new SubaccountsApi(config);

            try
            {
                // Update Agency details
                AgencySettings result = apiInstance.GetAgencySettings();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubaccountsApi.GetAgencySettings: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAgencySettingsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update Agency details
    ApiResponse<AgencySettings> response = apiInstance.GetAgencySettingsWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SubaccountsApi.GetAgencySettingsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**AgencySettings**](AgencySettings.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Agency details. |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getlogofile"></a>
# **GetLogoFile**
> Logo GetLogoFile ()

Get agency logo

 Get agency logo 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class GetLogoFileExample
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

            var apiInstance = new SubaccountsApi(config);

            try
            {
                // Get agency logo
                Logo result = apiInstance.GetLogoFile();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubaccountsApi.GetLogoFile: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetLogoFileWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get agency logo
    ApiResponse<Logo> response = apiInstance.GetLogoFileWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SubaccountsApi.GetLogoFileWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**Logo**](Logo.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Agency Logo Url  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getsubaccountdetails"></a>
# **GetSubaccountDetails**
> Subaccount GetSubaccountDetails (int id)

Get sub account details

 Get sub account details. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class GetSubaccountDetailsExample
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

            var apiInstance = new SubaccountsApi(config);
            var id = 56;  // int | Id

            try
            {
                // Get sub account details
                Subaccount result = apiInstance.GetSubaccountDetails(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubaccountsApi.GetSubaccountDetails: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetSubaccountDetailsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get sub account details
    ApiResponse<Subaccount> response = apiInstance.GetSubaccountDetailsWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SubaccountsApi.GetSubaccountDetailsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | Id |  |

### Return type

[**Subaccount**](Subaccount.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sub account details. |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |
| **403** | Forbidden  The current active plan does not include this feature, upgrade is required to use this feature.  |  -  |
| **404** | Not Found  Please verify the subaccount id is valid.  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getsubaccounts"></a>
# **GetSubaccounts**
> SubAccountListSucessResponsetBody GetSubaccounts (int? page = null, int? limit = null, string filterByEmail = null, bool? filterByActive = null, List<string> filterByIP = null, string orderby = null, OrderType ordertype = null)

Get Subaccounts lists information

 List subaccounts information 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class GetSubaccountsExample
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

            var apiInstance = new SubaccountsApi(config);
            var page = 1;  // int? | Page number (optional)  (default to 1)
            var limit = 10;  // int? | The numbers of rows per page to return (optional)  (default to 10)
            var filterByEmail = Jhon;  // string | Filter by email addresses that fully/partially match the search value. (optional) 
            var filterByActive = true;  // bool? | Filter by subaccount status. (optional) 
            var filterByIP = new List<string>(); // List<string> | Filter by IP Addresses. (optional) 
            var orderby = email;  // string | Field to sort by (optional)  (default to email)
            var ordertype = new OrderType(); // OrderType |  (optional) 

            try
            {
                // Get Subaccounts lists information
                SubAccountListSucessResponsetBody result = apiInstance.GetSubaccounts(page, limit, filterByEmail, filterByActive, filterByIP, orderby, ordertype);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubaccountsApi.GetSubaccounts: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetSubaccountsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get Subaccounts lists information
    ApiResponse<SubAccountListSucessResponsetBody> response = apiInstance.GetSubaccountsWithHttpInfo(page, limit, filterByEmail, filterByActive, filterByIP, orderby, ordertype);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SubaccountsApi.GetSubaccountsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int?** | Page number | [optional] [default to 1] |
| **limit** | **int?** | The numbers of rows per page to return | [optional] [default to 10] |
| **filterByEmail** | **string** | Filter by email addresses that fully/partially match the search value. | [optional]  |
| **filterByActive** | **bool?** | Filter by subaccount status. | [optional]  |
| **filterByIP** | [**List&lt;string&gt;**](string.md) | Filter by IP Addresses. | [optional]  |
| **orderby** | **string** | Field to sort by | [optional] [default to email] |
| **ordertype** | [**OrderType**](OrderType.md) |  | [optional]  |

### Return type

[**SubAccountListSucessResponsetBody**](SubAccountListSucessResponsetBody.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  Subaccounts list.  |  -  |
| **400** | Bad Request  ###### Produces:  * page_should_be_integer * page_should_be_greater_than_0 * limit_should_be_integer * limit_should_be_greater_than_0 * filter_by_active_should_be_boolean * ip_should_be_IPV4_format * order_by_can_only_be_email_or_last_used * ordertype_should_be_asc_or_desc  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |
| **403** | Forbidden  The current active plan does not include this feature, upgrade is required to use this feature.  |  -  |
| **404** | Not Found  Page not found.  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="subaccountauthenticationlogin"></a>
# **SubaccountAuthenticationLogin**
> AuthenticationLoginSucessResponsetBody SubaccountAuthenticationLogin (Email1 email1)

Login to a subaccount

 Login to a subaccount. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class SubaccountAuthenticationLoginExample
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

            var apiInstance = new SubaccountsApi(config);
            var email1 = new Email1(); // Email1 | 

            try
            {
                // Login to a subaccount
                AuthenticationLoginSucessResponsetBody result = apiInstance.SubaccountAuthenticationLogin(email1);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubaccountsApi.SubaccountAuthenticationLogin: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SubaccountAuthenticationLoginWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Login to a subaccount
    ApiResponse<AuthenticationLoginSucessResponsetBody> response = apiInstance.SubaccountAuthenticationLoginWithHttpInfo(email1);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SubaccountsApi.SubaccountAuthenticationLoginWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **email1** | [**Email1**](Email1.md) |  |  |

### Return type

[**AuthenticationLoginSucessResponsetBody**](AuthenticationLoginSucessResponsetBody.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  User logged in sucessfully, use the auth value as API Key from request body in future API calls.  |  -  |
| **400** | Bad Request  ###### Produces:  * missing_required_parameter_email  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |
| **403** | Forbidden  Email address or password provided are incorrect.  ###### Produces:   * wrong_credentials_specified * feature_not_available_for_active_plan  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updateagencysettings"></a>
# **UpdateAgencySettings**
> CommonSuccessResponseBody UpdateAgencySettings (BaseAgencySettings baseAgencySettings)

Update Agency details

 Update Agency Details 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class UpdateAgencySettingsExample
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

            var apiInstance = new SubaccountsApi(config);
            var baseAgencySettings = new BaseAgencySettings(); // BaseAgencySettings | 

            try
            {
                // Update Agency details
                CommonSuccessResponseBody result = apiInstance.UpdateAgencySettings(baseAgencySettings);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubaccountsApi.UpdateAgencySettings: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateAgencySettingsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update Agency details
    ApiResponse<CommonSuccessResponseBody> response = apiInstance.UpdateAgencySettingsWithHttpInfo(baseAgencySettings);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SubaccountsApi.UpdateAgencySettingsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **baseAgencySettings** | [**BaseAgencySettings**](BaseAgencySettings.md) |  |  |

### Return type

[**CommonSuccessResponseBody**](CommonSuccessResponseBody.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  Agency details updated sucessfully  |  -  |
| **400** | Bad Request  ###### Produces:  * agency_name_should_be_shorter_than_128_characters * agency_website_should_be_shorter_than_128_characters * agency_footer_should_be_shorter_than_2048_characters  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updatesubaccountdetails"></a>
# **UpdateSubaccountDetails**
> Subaccount UpdateSubaccountDetails (int id, SubaccountUpdateRequest subaccountUpdateRequest)

Update sub account details

 Update sub account details. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class UpdateSubaccountDetailsExample
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

            var apiInstance = new SubaccountsApi(config);
            var id = 56;  // int | Id
            var subaccountUpdateRequest = new SubaccountUpdateRequest(); // SubaccountUpdateRequest | 

            try
            {
                // Update sub account details
                Subaccount result = apiInstance.UpdateSubaccountDetails(id, subaccountUpdateRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubaccountsApi.UpdateSubaccountDetails: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateSubaccountDetailsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update sub account details
    ApiResponse<Subaccount> response = apiInstance.UpdateSubaccountDetailsWithHttpInfo(id, subaccountUpdateRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SubaccountsApi.UpdateSubaccountDetailsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | Id |  |
| **subaccountUpdateRequest** | [**SubaccountUpdateRequest**](SubaccountUpdateRequest.md) |  |  |

### Return type

[**Subaccount**](Subaccount.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sub account updated sucessfully. |  -  |
| **400** | Bad Request  ###### Produces:  * password_length_should_not_be_less_than_10_characters * password_should_contain_at_least_one_uppercase_character * password_should_contain_at_least_one_digit * password_should_equal_confirm_password * ip_should_be_IPV4_format * ip_not_associated_to_user_account * policy_agree_should_be_true  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |
| **403** | Forbidden  The current active plan does not include this feature, upgrade is required to use this feature.  |  -  |
| **404** | Not Found  Please verify the subaccount id is valid.  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updatesubaccountsmtplimit"></a>
# **UpdateSubaccountSMTPLimit**
> SubaccountActivePlan UpdateSubaccountSMTPLimit (int id, SubaccountSMTPLimit subaccountSMTPLimit)

Set subaccount smtp limit

 Set subaccount smtp limit. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class UpdateSubaccountSMTPLimitExample
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

            var apiInstance = new SubaccountsApi(config);
            var id = 56;  // int | Id
            var subaccountSMTPLimit = new SubaccountSMTPLimit(); // SubaccountSMTPLimit | 

            try
            {
                // Set subaccount smtp limit
                SubaccountActivePlan result = apiInstance.UpdateSubaccountSMTPLimit(id, subaccountSMTPLimit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubaccountsApi.UpdateSubaccountSMTPLimit: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateSubaccountSMTPLimitWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Set subaccount smtp limit
    ApiResponse<SubaccountActivePlan> response = apiInstance.UpdateSubaccountSMTPLimitWithHttpInfo(id, subaccountSMTPLimit);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SubaccountsApi.UpdateSubaccountSMTPLimitWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | Id |  |
| **subaccountSMTPLimit** | [**SubaccountSMTPLimit**](SubaccountSMTPLimit.md) |  |  |

### Return type

[**SubaccountActivePlan**](SubaccountActivePlan.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Subaccount smtp limit set sucessfully |  -  |
| **400** | Bad Request  ###### Produces:  * missing_required_parameter_limit * limit_should_be_integer * limit_should_not_be_higher_than_parent_account_limit * limit_should_not_be_lower_than_-1  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |
| **403** | Forbidden  The current active plan does not include this feature, upgrade is required to use this feature.  |  -  |
| **404** | Not Found  Please verify the subaccount id is valid.  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updatesubaccountstatus"></a>
# **UpdateSubaccountStatus**
> SubaccountActivePlan UpdateSubaccountStatus (int id, SubaccountActiveStatus subaccountActiveStatus)

Set subaccount status

 Set subaccount status. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class UpdateSubaccountStatusExample
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

            var apiInstance = new SubaccountsApi(config);
            var id = 56;  // int | Id
            var subaccountActiveStatus = new SubaccountActiveStatus(); // SubaccountActiveStatus | 

            try
            {
                // Set subaccount status
                SubaccountActivePlan result = apiInstance.UpdateSubaccountStatus(id, subaccountActiveStatus);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubaccountsApi.UpdateSubaccountStatus: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateSubaccountStatusWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Set subaccount status
    ApiResponse<SubaccountActivePlan> response = apiInstance.UpdateSubaccountStatusWithHttpInfo(id, subaccountActiveStatus);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SubaccountsApi.UpdateSubaccountStatusWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | Id |  |
| **subaccountActiveStatus** | [**SubaccountActiveStatus**](SubaccountActiveStatus.md) |  |  |

### Return type

[**SubaccountActivePlan**](SubaccountActivePlan.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Subaccount status set sucessfully |  -  |
| **400** | Bad Request  ###### Produces:  * missing_required_parameter_active * active_should_be_boolean   |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |
| **403** | Forbidden  The current active plan does not include this feature, upgrade is required to use this feature.  |  -  |
| **404** | Not Found  Please verify the subaccount id is valid.  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="uploadlogofile"></a>
# **UploadLogoFile**
> CommonSuccessResponseBody UploadLogoFile (System.IO.Stream file = null)

Upload agency logo

 Upload agency logo.  Logo must be a png or jpeg image. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class UploadLogoFileExample
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

            var apiInstance = new SubaccountsApi(config);
            var file = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream |  (optional) 

            try
            {
                // Upload agency logo
                CommonSuccessResponseBody result = apiInstance.UploadLogoFile(file);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SubaccountsApi.UploadLogoFile: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UploadLogoFileWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Upload agency logo
    ApiResponse<CommonSuccessResponseBody> response = apiInstance.UploadLogoFileWithHttpInfo(file);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SubaccountsApi.UploadLogoFileWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **file** | **System.IO.Stream****System.IO.Stream** |  | [optional]  |

### Return type

[**CommonSuccessResponseBody**](CommonSuccessResponseBody.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  The Logo file was successfully submitted.  |  -  |
| **400** | Bad Request  ###### Produces:  * missing_upload_file * file_type_should_be_png_or_jpeg  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


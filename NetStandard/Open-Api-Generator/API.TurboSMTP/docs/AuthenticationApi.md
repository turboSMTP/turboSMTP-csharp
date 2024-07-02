# API.TurboSMTP.Api.AuthenticationApi

All URIs are relative to *https://staging.api.serversmtp.com/api/v2*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AuthenticationLogin**](AuthenticationApi.md#authenticationlogin) | **POST** /authorize | Login - Get API Key |
| [**AuthenticationLogout**](AuthenticationApi.md#authenticationlogout) | **POST** /deauthorize | Logout - Revoke API Key |
| [**ChangePassword**](AuthenticationApi.md#changepassword) | **PUT** /change-password | Change turboSMTP password |
| [**CheckValidityTokenResetPassword**](AuthenticationApi.md#checkvaliditytokenresetpassword) | **GET** /forgot-password | Forgot Password - Verify if Secret Passord Recovery token is valid. |
| [**SendSecretTokenResetPassword**](AuthenticationApi.md#sendsecrettokenresetpassword) | **POST** /forgot-password | Forgot Password - Use in case you don´t remember your turboSMTP password |
| [**UpdateResetPassword**](AuthenticationApi.md#updateresetpassword) | **PUT** /forgot-password | Forgot Password - change password |

<a id="authenticationlogin"></a>
# **AuthenticationLogin**
> AuthenticationLoginSucessResponsetBody AuthenticationLogin (AuthenticationLoginRequestBody authenticationLoginRequestBody)

Login - Get API Key

**This endpoint allows you to get an API Key**  By providing your turboSMTP authentication details you will be able to get an API Key.  Use your API Key to consume APIs that require authorization. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class AuthenticationLoginExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://staging.api.serversmtp.com/api/v2";
            var apiInstance = new AuthenticationApi(config);
            var authenticationLoginRequestBody = new AuthenticationLoginRequestBody(); // AuthenticationLoginRequestBody | 

            try
            {
                // Login - Get API Key
                AuthenticationLoginSucessResponsetBody result = apiInstance.AuthenticationLogin(authenticationLoginRequestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticationApi.AuthenticationLogin: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AuthenticationLoginWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Login - Get API Key
    ApiResponse<AuthenticationLoginSucessResponsetBody> response = apiInstance.AuthenticationLoginWithHttpInfo(authenticationLoginRequestBody);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AuthenticationApi.AuthenticationLoginWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **authenticationLoginRequestBody** | [**AuthenticationLoginRequestBody**](AuthenticationLoginRequestBody.md) |  |  |

### Return type

[**AuthenticationLoginSucessResponsetBody**](AuthenticationLoginSucessResponsetBody.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  User logged in sucessfully, use the auth value as API Key from request body in future API calls.  |  -  |
| **400** | Bad Request  ###### Produces:  * missing_required_parameter  |  -  |
| **403** | Forbidden  Email address or password provided are incorrect.  ###### Produces:   * wrong_credentials_specified  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="authenticationlogout"></a>
# **AuthenticationLogout**
> CommonMessageResponseBody AuthenticationLogout ()

Logout - Revoke API Key

**This endpoint allows you to revoke your API Key** 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class AuthenticationLogoutExample
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

            var apiInstance = new AuthenticationApi(config);

            try
            {
                // Logout - Revoke API Key
                CommonMessageResponseBody result = apiInstance.AuthenticationLogout();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticationApi.AuthenticationLogout: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AuthenticationLogoutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Logout - Revoke API Key
    ApiResponse<CommonMessageResponseBody> response = apiInstance.AuthenticationLogoutWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AuthenticationApi.AuthenticationLogoutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**CommonMessageResponseBody**](CommonMessageResponseBody.md)

### Authorization

[consumerSecret](../README.md#consumerSecret), [ApiKeyAuth](../README.md#ApiKeyAuth), [consumerKey](../README.md#consumerKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  User logged out sucessfully, API Key is no longer valid.  |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="changepassword"></a>
# **ChangePassword**
> CommonSuccessResponseBody ChangePassword (ChangePasswordRequestBody changePasswordRequestBody)

Change turboSMTP password

**This endpoint allows you to change your current password**  ## PASSWORD RULES    * Passwords must have at least 10 characters.   * At least one character must be uppercase.   * At least one character must be lowercase.   * At least one character must be numeric. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class ChangePasswordExample
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

            var apiInstance = new AuthenticationApi(config);
            var changePasswordRequestBody = new ChangePasswordRequestBody(); // ChangePasswordRequestBody | 

            try
            {
                // Change turboSMTP password
                CommonSuccessResponseBody result = apiInstance.ChangePassword(changePasswordRequestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticationApi.ChangePassword: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ChangePasswordWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Change turboSMTP password
    ApiResponse<CommonSuccessResponseBody> response = apiInstance.ChangePasswordWithHttpInfo(changePasswordRequestBody);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AuthenticationApi.ChangePasswordWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **changePasswordRequestBody** | [**ChangePasswordRequestBody**](ChangePasswordRequestBody.md) |  |  |

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
| **200** | Sucess  Password changed sucessfully.     |  -  |
| **400** | Bad Request  ###### Produces:  * invalid_mail_address * current_password_is_missing * current_password_can_not_be_empty * password_is_missing * password_length_should_not_be_less_than_10_characters * password_should_contain_at_least_one_uppercase_character * password_should_contain_at_least_one_lowercase_character * password_should_contain_at_least_one_digit * confirm_password_is_missing * password_should_equal_confirm_password * new_password_should_not_equal_current_password              |  -  |
| **401** | Unauthorized  This API requires a valid API Key to be provided. (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  Produces:  * missing_authorization_key * invalid_authorization_key * account_is_inactive  |  -  |
| **403** | Forbidden  Current password provided is incorrect.  ###### Produces:   * password_is_invalid * not_allowed_for_apikey  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="checkvaliditytokenresetpassword"></a>
# **CheckValidityTokenResetPassword**
> CommonSuccessResponseBody CheckValidityTokenResetPassword (string token)

Forgot Password - Verify if Secret Passord Recovery token is valid.

Forgot Password - check if secret token is valid  **Note**: Tokens are valid for 1 hour. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class CheckValidityTokenResetPasswordExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://staging.api.serversmtp.com/api/v2";
            // Configure API key authorization: ApiKeyAuth
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new AuthenticationApi(config);
            var token = "token_example";  // string | Secret Token

            try
            {
                // Forgot Password - Verify if Secret Passord Recovery token is valid.
                CommonSuccessResponseBody result = apiInstance.CheckValidityTokenResetPassword(token);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticationApi.CheckValidityTokenResetPassword: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CheckValidityTokenResetPasswordWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Forgot Password - Verify if Secret Passord Recovery token is valid.
    ApiResponse<CommonSuccessResponseBody> response = apiInstance.CheckValidityTokenResetPasswordWithHttpInfo(token);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AuthenticationApi.CheckValidityTokenResetPasswordWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **token** | **string** | Secret Token |  |

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
| **200** | Sucess  Token is valid.    |  -  |
| **400** | Bad Request  ###### Produces:  * forgot_password_token_is_missing  |  -  |
| **403** | Forbidden  Token is invalid.    |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="sendsecrettokenresetpassword"></a>
# **SendSecretTokenResetPassword**
> CommonSuccessResponseBody SendSecretTokenResetPassword (SendSecretTokenResetPasswordRequestBody sendSecretTokenResetPasswordRequestBody)

Forgot Password - Use in case you don´t remember your turboSMTP password

**This endpoint will allow you to get an email that will help you reset your turboSMTP password**  In your password reset email you will find:  * A **Reset Password** button that will take you to the password reset form on turboSMTP website. * A secret token to be used to reset the password via [/authentication/forgot-password](#/authentication/updateResetPassword). **Note**: Token is vaid for 1 hour. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class SendSecretTokenResetPasswordExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://staging.api.serversmtp.com/api/v2";
            var apiInstance = new AuthenticationApi(config);
            var sendSecretTokenResetPasswordRequestBody = new SendSecretTokenResetPasswordRequestBody(); // SendSecretTokenResetPasswordRequestBody | 

            try
            {
                // Forgot Password - Use in case you don´t remember your turboSMTP password
                CommonSuccessResponseBody result = apiInstance.SendSecretTokenResetPassword(sendSecretTokenResetPasswordRequestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticationApi.SendSecretTokenResetPassword: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SendSecretTokenResetPasswordWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Forgot Password - Use in case you don´t remember your turboSMTP password
    ApiResponse<CommonSuccessResponseBody> response = apiInstance.SendSecretTokenResetPasswordWithHttpInfo(sendSecretTokenResetPasswordRequestBody);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AuthenticationApi.SendSecretTokenResetPasswordWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **sendSecretTokenResetPasswordRequestBody** | [**SendSecretTokenResetPasswordRequestBody**](SendSecretTokenResetPasswordRequestBody.md) |  |  |

### Return type

[**CommonSuccessResponseBody**](CommonSuccessResponseBody.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  Password reset email with instructions was sent to your turboSMTP email account.     |  -  |
| **400** | Bad Request  ###### Produces:  * empty_request_body * missing_required_parameter     |  -  |
| **404** | Not Found  Please verify the email address provided is the one you used to register at turboSMTP.  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updateresetpassword"></a>
# **UpdateResetPassword**
> CommonSuccessResponseBody UpdateResetPassword (UpdateResetPasswordRequestBody updateResetPasswordRequestBody)

Forgot Password - change password

**This endpoint allows you to reset your password by using a password reset token**  ## PASSWORD RULES    * Passwords must have at least 10 characters.   * At least one character must be uppercase.   * At least one character must be lowercase.   * At least one character must be numeric. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;

namespace Example
{
    public class UpdateResetPasswordExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://staging.api.serversmtp.com/api/v2";
            var apiInstance = new AuthenticationApi(config);
            var updateResetPasswordRequestBody = new UpdateResetPasswordRequestBody(); // UpdateResetPasswordRequestBody | 

            try
            {
                // Forgot Password - change password
                CommonSuccessResponseBody result = apiInstance.UpdateResetPassword(updateResetPasswordRequestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticationApi.UpdateResetPassword: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateResetPasswordWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Forgot Password - change password
    ApiResponse<CommonSuccessResponseBody> response = apiInstance.UpdateResetPasswordWithHttpInfo(updateResetPasswordRequestBody);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AuthenticationApi.UpdateResetPasswordWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **updateResetPasswordRequestBody** | [**UpdateResetPasswordRequestBody**](UpdateResetPasswordRequestBody.md) |  |  |

### Return type

[**CommonSuccessResponseBody**](CommonSuccessResponseBody.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Sucess  Password reset sucessfully.     |  -  |
| **400** | Bad Request  ###### Produces:  * empty_request_body * token_is_missing * token_can_not_be_empty * password_is_missing * password_length_should_not_be_less_than_10_characters * password_should_contain_at_least_one_uppercase_character * password_should_contain_at_least_one_lowercase_character * password_should_contain_at_least_one_digit * confirm_password_is_missing * password_should_equal_confirm_password  |  -  |
| **403** | Forbidden  Token is invalid.    |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


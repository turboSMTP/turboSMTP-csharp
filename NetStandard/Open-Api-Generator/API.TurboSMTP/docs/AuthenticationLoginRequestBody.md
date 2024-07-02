# API.TurboSMTP.Model.AuthenticationLoginRequestBody

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Email** | **string** | The email of turboSMTP account | 
**Password** | **string** | The password of turboSMTP account | 
**NoExpire** | **bool** |  **false**:  authentication will expire after 2 hours.  **true**:  authentication will keep you signed in, and will never expire. (Use [/authentication/deauthorize](#/authentication/AuthenticationLogout) to logout and release your an API Key) | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


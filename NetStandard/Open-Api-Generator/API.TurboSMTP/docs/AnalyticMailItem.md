# API.TurboSMTP.Model.AnalyticMailItem
Sent Email

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **long** | Email Id. | [optional] 
**Subject** | **string** | Email Subject. | [optional] 
**Sender** | **string** | Email Sender. | [optional] 
**Recipient** | **string** | Email Recipient. | [optional] 
**SendTime** | **string** | Date Time email was sent. | [optional] 
**Status** | **AnalyticMailStatus** |  | [optional] 
**Domain** | **string** | The portion of the sender´s email address after the \&quot;@\&quot; symbol. | [optional] 
**ContactDomain** | **string** | The portion of the recipient´s email address after the \&quot;@\&quot; symbol. | [optional] 
**XCampaignId** | **string** | Value specified in the x_campaign_id custom header to track campaigns specific data. | [optional] 
**Error** | **string** | Error returned when delivering the email message. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


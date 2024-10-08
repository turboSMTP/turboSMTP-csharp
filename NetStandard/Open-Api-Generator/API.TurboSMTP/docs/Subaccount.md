# API.TurboSMTP.Model.Subaccount

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Email** | **string** |  | 
**Ip** | **string** | IP address to use for sending emails. | [optional] 
**Active** | **bool** | Active subaccounts can be used for login purpose, while users can´t login to inactive subaccounts. Notice that in order to be able to send emails the subaccount subscription must also be active. User can set subaccounts to active / inactive from the dashboard. | 
**SubaccountId** | **int** | Sub account Id | [optional] 
**ParentId** | **int** | Sub account parent Id | [optional] 
**FirstName** | **string** | subaccount owner first name | [optional] 
**LastName** | **string** | subaccount owner last name | [optional] 
**Address1** | **string** | Address Line 1 | [optional] 
**Address2** | **string** | Address Line 2 | [optional] 
**City** | **string** | City | [optional] 
**CompanyName** | **string** | Agency Name | [optional] 
**Country** | **string** | Country | [optional] 
**Region** | **string** | Region | [optional] 
**ZipCode** | **string** | Zip Code | [optional] 
**PhoneNumber** | **string** | Phone Number | [optional] 
**PolicyAgree** | **bool** | Policy must be agreed in order to be able to create a subaccount. | [optional] 
**SiteUrl** | **string** | Website | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


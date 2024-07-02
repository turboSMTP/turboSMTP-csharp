# API.TurboSMTP.Model.SubaccountListItem

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Email** | **string** |  | 
**Ip** | **string** | IP address to use for sending emails. | [optional] 
**Active** | **bool** | Active subaccounts can be used for login purpose, while users can´t login to inactive subaccounts. Notice that in order to be able to send emails the subaccount subscription must also be active. User can set subaccounts to active / inactive from the dashboard. | 
**SubaccountId** | **int** | Sub account Id | [optional] 
**ParentId** | **int** | Sub account parent Id | [optional] 
**Limit** | **int** | The ammount of emails the sub account is allowed to send over the period specified by plan_limit_interval. Value -1 means no limit. | 
**Sent** | **int** | The ammount of sent emails from the sub account over the current period. | [optional] 
**LastUsed** | **string** | The date time the sub account was last used. | [optional] 
**PlanExpiration** | **string** | Expiration date time of the plan. | [optional] 
**PlanLimitInterval** | **SmtpLimitInterval** |  | [optional] 
**Expired** | **bool** | Expired if plan expiration date is overdue. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


# API.TurboSMTP.Model.SubaccountPlanBase

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Limit** | **int** | The ammount of emails the sub account is allowed to send over the period specified by plan_limit_interval. Value -1 means no limit. | 
**Sent** | **int** | The ammount of sent emails from the sub account over the current period. | [optional] 
**LastUsed** | **string** | The date time the sub account was last used. | [optional] 
**PlanExpiration** | **string** | Expiration date time of the plan. | [optional] 
**PlanLimitInterval** | **SmtpLimitInterval** |  | [optional] 
**Expired** | **bool** | Expired if plan expiration date is overdue. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


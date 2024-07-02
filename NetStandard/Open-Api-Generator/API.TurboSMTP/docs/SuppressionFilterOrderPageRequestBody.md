# API.TurboSMTP.Model.SuppressionFilterOrderPageRequestBody

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**From** | **DateTime** | Start date | 
**To** | **DateTime** | End date | 
**Tz** | **string** | Timezone Offset | [optional] 
**Filter** | **string** | Query to search | [optional] 
**FilterBy** | [**List&lt;SuppressionSource&gt;**](SuppressionSource.md) | Filter by | [optional] 
**SmartSearch** | **bool?** | Smart search | [optional] [default to false]
**Restrict** | [**List&lt;SuppressionRestriction&gt;**](SuppressionRestriction.md) | xxxx | [optional] 
**Orderby** | **SuppressionOrderBy** |  | [optional] 
**Ordertype** | **OrderType** |  | [optional] 
**Page** | **int?** | Page number | [optional] [default to 1]
**Limit** | **int?** | The numbers of rows per page to return | [optional] [default to 10]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


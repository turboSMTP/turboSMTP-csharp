# API.TurboSMTP.Model.EmailRequestBody

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Authuser** | **string** | email of turboSMTP account | [optional] 
**Authpass** | **string** | password of turboSMTP account | [optional] 
**From** | **string** | from mail address | [optional] 
**To** | **string** | comma-separated recipients emails list | [optional] 
**Subject** | **string** | email subject | [optional] 
**Cc** | **string** | comma-separated copy emails list | [optional] 
**Bcc** | **string** | comma-separated hidden copy emails list | [optional] 
**Content** | **string** | text content of the email | [optional] 
**HtmlContent** | **string** | html content of the email | [optional] 
**CustomHeaders** | **Dictionary&lt;string, string&gt;** | email additional headers, use any additional header like standard ones List-Unsubscribe (to allow users to easily unsubscribe), X-Entity-Ref-ID (to handle how gmail and other clients group threads), and your own ones.   | [optional] 
**ReferenceId** | **string** | custom argument included within an email to be added to the Event Webhook response. | [optional] 
**MimeRaw** | **string** | mime message which replaces content and hmtl content | [optional] 
**Attachments** | [**List&lt;Attachment&gt;**](Attachment.md) | array of attachment objects | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


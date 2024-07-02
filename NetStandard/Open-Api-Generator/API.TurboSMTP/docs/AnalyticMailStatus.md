# API.TurboSMTP.Model.AnalyticMailStatus
Send Mail Status:  NEW: email has been queued for delivery DEFER: email is in the queue for delivery SUCCESS: email has been delivered. OPEN: email has been opened. CLICK: email has been clicked. REPORT: email has been reported as spam. FAIL: email has bounced. SYSFAIL: email was dropped. UNSUB: email is unsubscribed.  Notice that emails that fall into the above statuses can be grouped, ie Turbo-Smtp uses the following groups:    'Clicks' = 'CLICK',   'Unsubscribes' = 'UNSUB',   'Spam' = 'REPORT',   'Drop' = 'SYSFAIL',   'Queued' = 'NEW' or 'DEFER',   'Opens'= 'OPEN' or 'CLICK' or 'UNSUB' or 'REPORT',   'Delivered'= 'SUCCESS'  or 'OPEN' or 'CLICK' or 'UNSUB' or 'REPORT',   'Bounce': 'FAIL'. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


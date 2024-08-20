[api_reference]: https://serversmtp.com/turbo-api/
[openapi_generator]: https://openapi-generator.tech/

This documentation is based on our [Open API Specification][api_reference]

# This SDK consists of 2 Core projects + 1 Testing Project.

## **API.TurboSMTP**

This project provides a wrapper for the turboSMTP API. It is automatically generated from our Open API Specification V3 using the [Open API Generator Client][openapi_generator]

## **turboSMTP**

This project offers a higher-level wrapper for **API.TurboSMTP**, simplifying usage by abstracting infrastructure details and the complexities of REST API connections.

## **turboSMTP.Test**

This project is intended for unit testing the TurboSMTP project. It includes a suite of tests to ensure the correctness, reliability, and performance of the TurboSMTP functionality. By providing comprehensive test coverage, it helps maintain the integrity of the SDK as new features are added or existing ones are modified.

# INITIALIZATION

```csharp
using System.Configuration;
using TurboSMTP;

//Build the TurboSMTP Configuration.
TurboSMTPClientConfiguration.Builder()
                .SetConsumerKey(ConfigurationManager.AppSettings["ConsumerKey"])
                .SetConsumerSecret(ConfigurationManager.AppSettings["ConsumerSecret"])
                .SetServerURL(ConfigurationManager.AppSettings["ServerUrl"])
                .SetSendServerURL(ConfigurationManager.AppSettings["SendServerUrl"])
                .SetTimeZone("-03:00")
                .Build();

//Create a new instance of TurboSMTPClient
var TSClient = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

```

# Table of Contents

* [Email Messages](#email-messages)
* [Relays](#relays)
* [Suppressions](#suppressions)
* [Email Validator](#email-validator)
* [Email Validator Files](#email-validator-files)
* [Email Validator File Results](#email-validator-file-results)

# Email Messages

## Send Email Messages

The Send method is an asynchronous task that handles the process of sending an email message. The method takes an `EmailMessage` object as input and returns a `SendDetails` object, which contains the result of the email sending operation.

```csharp
//Create an instance of EmailMessage
var emailMessage = new EmailMessage.Builder()
                .SetFrom("sender@your-domain.com")
                .AddTo("recipient@recipient-domain.com")
                .SetSubject("Trivia contest simple email")
                .SetHtmlContent("Do not loose the opportunity to participate.")
                .Build();

//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Send the email message
var sendResult = await client.Emails.Send(emailMessage);

//Evaluate the MessageID assigned to the sent message            
Console.WriteLine(sendResult.MessageID);
```

# Relays

## Query Relays Details

## Export Relays Details To CSV
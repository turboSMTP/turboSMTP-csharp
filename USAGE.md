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

The **Send** method is an asynchronous operation that handles the process of sending an email message. The method takes an `EmailMessage` object as input and returns a `SendDetails` object, which contains the result of the email sending operation.

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

The **Query** method is an asynchronous operation designed to retrieve paginated results of relay data based on specified query options. The method takes a `RelaysQueryOptions` object as input and returns PagedListResults<Relay> object, which contains the total number of records and a list of Relay objects.

```csharp
//Create an instance of RealysQueryOptions
var queryOptions = new RelaysQueryOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .Build();

//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Query Relays
var pagedList = await client.Relays.Query(queryOptions);

//Evaluate the total ammount of records according to the queryOptions.
Console.WriteLine(pagedList.TotalRecords);

//Evaluate the Subject of the fist Relay.
Console.WriteLine(pagedList.Records.First().Subject);
```

## Export Relays Details To CSV

The **Export** method is an asynchronous operation designed to export relay data based on specified export options. The method takes a `RelaysExportOptions` object as input  and returns the data in CSV formated string, which can then be saved or further processed.

```csharp
//Create an instance of RealysExportOptions
var exportOptions = new RelaysExportOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .Build();

//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Export Relays
var csvContent = await client.Relays.Export(exportOptions);

//Save content to a CSV File.
File.WriteAllText(filePath, csvContent);
```

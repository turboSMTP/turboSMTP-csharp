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

The **SendAsync** method is an asynchronous operation that handles the process of sending an email message. The method takes an `EmailMessage` object as input and returns a `SendDetails` object, which contains the result of the email sending operation.

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
var sendResult = await client.Emails.SendAsync(emailMessage);

//Evaluate the MessageID assigned to the sent message            
Console.WriteLine(sendResult.MessageID);
```

# Relays

## Query Relays Details

The **QueryAsync** method is an asynchronous operation designed to retrieve paginated results of relay data based on specified query options. The method takes a `RelaysQueryOptions` object as input and returns PagedListResults<Relay> object, which contains the total number of records and a list of Relay objects.

```csharp
//Create an instance of RealysQueryOptions
var queryOptions = new RelaysQueryOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .Build();

//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Query Relays
var pagedList = await client.Relays.QueryAsync(queryOptions);

//Evaluate the total ammount of records according to the queryOptions.
Console.WriteLine(pagedList.TotalRecords);

//Evaluate the Subject of the fist Relay.
Console.WriteLine(pagedList.Records.First().Subject);
```

## Export Relays Details To CSV

The **ExportAsync** method is an asynchronous operation designed to export relay data based on specified export options. The method takes a `RelaysExportOptions` object as input  and returns the data in CSV formated string, which can then be saved or further processed.

```csharp
//Create an instance of RealysExportOptions
var exportOptions = new RelaysExportOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .Build();

//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Export Relays
var csvContent = await client.Relays.ExportAsync(exportOptions);

//Save content to a CSV File.
File.WriteAllText(filePath, csvContent);
```

# Suppressions

## Add a Single Suppression

The **AddAsync** method is an asynchronous operation that handles the process of adding an email address to the suppressions list. The method takes the *reason for the suppression* and the *email address to add to the suppresions list* as input and returns a `SuppressionsAddResult` object, which contains the result of the Add operation.

```csharp
var suppressionReason = "Manual Processing of Removal Request";
var suppressionEmailAddress = "recipient@recipient.domain.com";

//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Add the Email Address to the Suppressions List.
var addSuppressionsResult = await client.Suppressions.AddAsync(suppressionReason,suppressionEmailAddress);

//Evaluate if the Suppression was Successfully Processed.
if (addSuppressionsResult.Valid.Contains(suppressionEmailAddress))
{
    Console.WriteLine("OK");
}
```

## Add Multiple Suppressions

The **AddRangeAsync** method is an asynchronous operation that handles the process of adding multiple email addresses to the suppressions list. The method takes the *reason for the suppressions* and a list of *email addresses to add to the suppresions list* as input and returns a `SuppressionsAddResult` object, which contains the result of the AddRange operation.

```csharp
var suppressionReason = "Manual Processing of Removal Request";

//Create a Test List of email addresses
var testEmailAddresses = new List<string>()
{
    "first-recipient@recipient.domain.com",
    "second-recipient@recipient.domain.com",
    "invalid-recipient@malformed-domain"
};

//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Add the Test Mail Addresses to the Suppressions List
var addSuppressionsResult = await client.Suppressions.AddRangeAsync(suppressionReason, testEmailAddresses);

//Evaluate Suppressions Processing Result
foreach (var validEmailAddress in addSuppressionsResult.Valid)
{
    Console.WriteLine($"Valid: {validEmailAddress}");
}
foreach (var inValidEmailAddress in addSuppressionsResult.Invalid)
{
    Console.WriteLine($"Invalid: {inValidEmailAddress}");
}
```

## Query Suppressions

The **QueryAsync** method is an asynchronous operation designed to retrieve paginated results of suppressions data based on specified query options. The method takes a `SuppressionsQueryOptions` object as input and returns PagedListResults<Suppression> object, which contains the total number of records and a list of Suppresion objects.

```csharp
//Create an instance of SuppressionsQueryOptions
var queryOptions = new SuppressionsQueryOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .Build();

//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Query Suppressions
var pagedList = await client.Suppressions.QueryAsync(queryOptions);

//Evaluate the total ammount of records according to the queryOptions.
Console.WriteLine(pagedList.TotalRecords);

//Evaluate the Recipient of the fist Suppression.
Console.WriteLine(pagedList.Records.First().Recipient);
```

## Export Suppressions To CSV

The **ExportAsync** method is an asynchronous operation designed to export suppressions data based on specified export options. The method takes a `SuppressionsExportOptions` object as input and returns the data in CSV formated string, which can then be saved or further processed.

```csharp
//Create an instance of SuppressionsExportOptions
var exportOptions = new SuppressionsExportOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .Build();

//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Export Suppressions
var csvContent = await client.Suppressions.ExportAsync(exportOptions);

//Save content to a CSV File.
File.WriteAllText(filePath, csvContent);
```

## Delete a Single Suppression

The **DeleteAsync** method is an asynchronous operation that handles the process of removing an email address from the suppressions list. The method takes the *email address to remove from the suppressions list* as input and returns a boolean result that indicates if the deletion was successful.

```csharp
var suppressionEmailAddress = "recipient@recipient.domain.com";

//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Remove Suppression
var success = await client.Suppressions.DeleteAsync(suppressionEmailAddress);

//Evaluate if the Suppression was Successfully Removed.
if (success)
{
    Console.WriteLine("Removed");
}
```

## Delete Multiple Suppressions

The **DeleteRangeAsync** method is an asynchronous operation that handles the process of removing multiple email addresses from the suppressions list. The method takes a list of *email addresses to remove from the suppresions list* as input and returns a boolean result, that indicates if the deletion was successful.

```csharp
var testEmailAddresses = new List<string>()
            {
                "first-recipient@recipient.domain.com",
                "second-recipient@recipient.domain.com",
                "third-recipient@recipient.domain.com",
            };

//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Remove Suppressions
var success = await client.Suppressions.DeleteRangeAsync(testEmailAddresses);

//Evaluate if the suppressions were Successfully Removed.
if (success)
{
    Console.WriteLine("Removed");
}
```

## Delete Suppressions Based on a Criteria

The **DeleteAsync** method is an asynchronous operation that handles the process of removing multiple email addresses from the suppressions list according to a filter Criteria. The method takes a `SuppressionsDeleteOptions` object as input and returns a boolean result, that indicates if the deletion was successful.

```csharp
//Create an instance of SuppressionsDeleteOptions
var deleteOptions = new SuppressionsDeleteOptions.Builder()
                .SetFrom(DateTime.Now.AddMonths(-1))
                .SetTo(DateTime.Now)
                .Build();

//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Remove Suppressions
var success = await client.Suppressions.DeleteAsync(deleteOptions);

//Evaluate if the suppressions were Successfully Removed.
if (success)
{
    Console.WriteLine("Removed");
}
```

# Email Validator

## Get Email Validator Subscription.

The **GetEmailValidatorSubscriptionAsync** method is an asynchronous operation that handles the process of retrieving Email Validator Subsctiption details. The method  returns an `EmailValidatorSubscription` object.

```csharp
//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Retrieve Email Validator Subscription
var emailValidatorSubscription = await client.EmailValidator.GetEmailValidatorSubscriptionAsync();

//Evaluate remaining credits.
Console.WriteLine($"Free Credits: {emailValidatorSubscription.FreeCredits}");
Console.WriteLine($"Paid Credits: {emailValidatorSubscription.PaidCredits}");
```

## Validate a Single Email Address.

The **ValidateAsync** method is an asynchronous operation that handles the process of validating an email address. The method takes the *email address to validate* as input and returns an `EmailAddressValidationDetails` object.

```csharp
//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Retrieve Email Address Validation Details
var emailAddressValidationDetails = await client.EmailValidator.ValidateAsync("recipient@recipient-domain.com");

//Evaluate Email Address Validation Details
Console.WriteLine($"Status: {emailAddressValidationDetails.Status} - {emailAddressValidationDetails.SubStatus}");
Console.WriteLine($"Free: {emailAddressValidationDetails.FreeEmail}");
```

# Email Validator Files

## Add a File of Email Addresses

The **AddAsync** method is an asynchronous operation that handles the process of adding a list of email addresses. The method takes the *filename* and a list of *email addresses* as input and returns the id of the list just added.

```csharp
//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Create a sample list of email addresses.
var contactsDetails = new List<string>()
    {
        "recipient1@domain.com",
        "recipient2@domain.com"
    };

//Add a file named "contacts.txt" with the list of email addresses
var fileId = await client.EmailValidatorFiles.AddAsync("contacts.txt", contactsDetails);
```

## Get Single File Details

The **GetAsync** method is an asynchronous operation designed to retrieve file data based on a specific file identifier. The method takes the *id* as input and returns an EmailValidatorFile object.

```csharp
//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Get Email Validator File Details
var emailValidatorFile = await client.EmailValidatorFiles.GetAsync(fileId);

//Evaluate the File Details.
Console.WriteLine($"File: {emailValidatorFile.FileName} - Processed: {emailValidatorFile.IsProcessed}");
```

## Query Files Details

The **QueryAsync** method is an asynchronous operation designed to retrieve paginated results of files data based on specified query options. The method takes an `EmailValidatorFilesQueryOptions` object as input and returns PagedListResults<EmailValidatorFile> object, which contains the total number of records and a list of EmailValidatorFile objects.

```csharp
//Create an instance of EmailValidatorFilesQueryOptions
var queryOptions = new EmailValidatorFilesQueryOptions.Builder()
    .SetFrom(DateTime.Now.AddYears(-3))
    .SetTo(DateTime.Now)
    .Build();

//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Query Email Validator Files
var pagedList = await client.EmailValidatorFiles.QueryAsync(queryOptions);

//Evaluate the total ammount of records according to the queryOptions.
Console.WriteLine(pagedList.TotalRecords);

//Evaluate Processing Status of all returened files.
foreach (var file in pagedList.Records) 
{
    Console.WriteLine($"File: {file.FileName} - Processed: {file.IsProcessed}");
}
```

## Validate a File

The **ValidateAsync** method is an asynchronous operation designed to validate (process) a file based on a specific file identifier. The method takes the *id* as input and returns a boolean indicating if validation was sucessfull or not.

```csharp
//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Validate file
var validationResult = await client.EmailValidatorFiles.ValidateAsync(fileId);

//Evaluate the validation result.
if (validationResult)
    Console.WriteLine("Validation OK");
```

## Delete a File

The **DeleteAsync** method is an asynchronous operation designed to delete a file based on a specific file identifier. The method takes the *id* as input and returns a boolean indicating if validation was sucessfull or not.

```csharp
//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Delete a file
var deleteResult = await client.EmailValidatorFiles.DeleteAsync(fileId);

//Evaluate the delete result.
if (deleteResult)
  Console.WriteLine("File has been deleted.");
```

# Email Validator File Results

## Query File Validation Results

The **QueryAsync** method is an asynchronous operation designed to retrieve paginated results of validation results data based on specified query options. The method takes an `EmailValidatorFileResultsQueryOptions` object as input and returns PagedListResults<EmailAddressValidationDetails> object, which contains the total number of records and a list of EmailAddressValidationDetails objects.

```csharp
//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Query file results
var pagedList = await client.EmailValidatorFileResults.QueryAsync(queryOptions);

//Evaluate the total ammount of records according to the queryOptions.
Console.WriteLine(pagedList.TotalRecords);

//Evaluate Processing Status of all returened files.
foreach (var emailAddressValidationDetails in pagedList.Records)
{
    Console.WriteLine($"Email: {emailAddressValidationDetails.Email} - Status: {emailAddressValidationDetails.Status}");
}
```

## Export File Validation Results To CSV

The **Export** method is an asynchronous operation designed to export file validation results based on specified export options. The method takes the *id* as input as input and returns the data in CSV formated string, which can then be saved or further processed.

```csharp
//Create a new instance of TurboSMTPClient
var client = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

//Export file results
var csvContent = await client.EmailValidatorFileResults.ExportAsync(fileId);

//Save content to a CSV File.
File.WriteAllText(filePath, csvContent);
```

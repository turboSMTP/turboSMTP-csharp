[turboSMTP_home]: https://serversmtp.com/
[api_reference]: https://serversmtp.com/turbo-api/
[turboSMTP_sign_up]: https://serversmtp.com/en/tsmtpregistration1.php
[turboSMTP_analytics_dashboard]: https://dashboard.serversmtp.com/analytics/overview
[turboSMTP_webhooks_reference]: https://serversmtp.com/event-webhook-reference/
[turboSMTP_about_us]: https://serversmtp.com/about-us/
[turboSMTP_contact_us]: https://serversmtp.com/contact-us/
[sdk_email]: mailto:sdk@turbo-smtp.com

<img class="header-image is-logo-image" alt="smtp mail server – professional SMTP service provider" src="https://serversmtp.com/wp-content/uploads/2022/02/logo_2021-2.svg" width="290" height="56">

# turboSMTP-csharp SDK
The **Official turboSMTP C#**, .NetStandard, .NetCore SDK - enables .Net Developers to work with [turboSMTP API][api_reference] efficiently.

* [turboSMTP Home][turboSMTP_home]
* [turboSMTP API documentation][api_reference]
  
## Table of contents

- [Release notes](#release-notes)
- [Getting Started](#getting-started)
  - [Requirements](#requirements)
  - [API Key](#api-key)
  - [Base URL](#base-url)
    - [Sending Server URL](#sending-server-url-sendserverurl)
    - [General Server URL](#general-server-url-serverurl)
- [Quick start with TurboSMTP Client](#quick-start-with-turbosmtp-client)
  - [TurboSMTP Client Configuration Initialization](#turbosmtp-client-configuration-initialization)
  - [TurboSMTP Client Configuration Usage](#turbosmtp-client-configuration-usage)
  - [TurboSMTP Client Initialization](#turbosmtp-client-initialization)
  - [TurboSMTP Client Hello World Email example](#turbosmtp-client-hello-world-email-example)
- [Usage](#usage)
  - [SDK Library Documentation](USAGE.md)
  - [Common SDK Use Cases Examples](USE_CASES.md)
- [Contribute](#contribute)
  - [Reporting Bugs](CONTRIBUTING.md#reporting-bugs)
  - [Requesting New Features](CONTRIBUTING.md#requesting-new-features)
  - [How to Submit an Issue or Feature Request](CONTRIBUTING.md#how-to-submit-an-issue-or-feature-request)
- [Troubleshooting](#troubleshooting)
- [About](#about)
- [Support](#support)
- [License](#license)

## Release notes

Changes to the SDK beginning with version 2.0.0 (August 2024) are tracked in [CHANGELOG.md][changes-file].

## Getting Started

### Requirements

- **.NET Framework 4.8+**.
- **A turboSMTP account**, [sign up for free][turboSMTP_sign_up] to send up to 6.000 FREE emails per month (No Obligation - No Credit card required).

### API Key

Create your API Key from [turboSMTP Dashboard](https:).

### Base URL

#### Sending Server URL (**SendServerURL**)

turboSMTP allows sending and receiving an email worldwide, for better sending experience, turboSMTP offers 2 regions.

For **european region** use the sending URL:

```
https://api.eu.turbo-smtp.com/api/v2
```

For **other regions** use the sending URL:

```
https://api.turbo-smtp.com/api/v2
```

#### General Server URL (**ServerURL**)

```
https://api.turbo-smtp.com/api/v2
```
## Quick start with TurboSMTP Client

In order to facilitate construction and usage of **TurboSMTPClientConfiguration**, it´s been built as a combination of *Builder + Singleton* design patterns:

### TurboSMTP Client Configuration Initialization

As stated above, **TurboSMTPClientConfiguration** uses a builder design pattern that allows to setup your `ConsumerKey` and `Secret`, `ServerURL` and `SendServerURL`, and your `Timezone` that will be used to consume time sensitive data, like when filtering data by dates.

```csharp
using System.Configuration;
using TurboSMTP;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new TurboSMTPClientConfiguration.Builder()
                .SetConsumerKey(ConfigurationManager.AppSettings["ConsumerKey"])
                .SetConsumerSecret(ConfigurationManager.AppSettings["ConsumerSecret"])
                .SetServerURL(ConfigurationManager.AppSettings["ServerUrl"])
                .SetSendServerURL(ConfigurationManager.AppSettings["SendServerUrl"])
                .SetTimeZone("-03:00")
                .Build();
        }
    }
}
```

### TurboSMTP Client Configuration Usage 

As stated above, **TurboSMTPClientConfiguration** uses a singleton design pattern, once it´s been already setup once (it´s suggested you setup anytime during your application initialization), you can simply access it´s *Instance* property as:

```csharp
var configuration = TurboSMTPClientConfiguration.Instance
```

### TurboSMTP Client Initialization

In order to create a **TurboSMTPClient** simply pass a **TurboSMTPClientConfiguration** to it´s constructor as:

```csharp
var TSClient = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
```

### TurboSMTP Client Hello World Email example

```csharp
using System.Threading.Tasks;
using TurboSMTP;
using TurboSMTP.Domain;

namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Create an Email Message
            var emailMessage = new EmailMessage.Builder()
                .SetFrom("sender@yourdomain.com")
                .AddTo("recipient@domain.com")
                .SetSubject("Hello World Simple Email")
                .SetHtmlContent("This email has been sent using <b>turboSMTP SDK</b>.")
                .Build();

            //Create a TurboSMTPClient Instance
            var TSClient = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

            //Send your Email Message
            var result = await TSClient.Emails.SendAsync(emailMessage);
        }
    }
}
```

*After executing the above code, `result.Message` should be `OK` and `MessageID` should contain a reference number to your sending operation, and you should have an email in the inbox of the `to` recipient. You can check the status of your email [in the UI][turboSMTP_analytics_dashboard], or using **TurboSMTPClient.Relays.QueryAsync()** method. Alternatively, we can post events to a URL of your choice using our [Event Webhooks][turboSMTP_webhooks_reference]. This gives you information about the events that occur as turboSMTP processes your email.* 

# Usage

- [SDK Library Documentation](USAGE.md)
- [Common SDK Use Cases Examples](USE_CASES.md)

# Contribute

Thank you for considering contributing to our SDK! We welcome all forms of contributions, including bug reports and feature requests. 

Your feedback is invaluable in helping us improve and expand our SDK, please refere to our [CONTRIBUTING](CONTRIBUTING.md) guide for details.

For any inquiries, you can contact us at the following email address:

**Email:** [sdk@turbo-smtp][sdk_email]

Quick links:

- [Reporting Bugs](CONTRIBUTING.md#reporting-bugs)
- [Requesting New Features](CONTRIBUTING.md#requesting-new-features)
- [How to Submit an Issue or Feature Request](CONTRIBUTING.md#how-to-submit-an-issue-or-feature-request)

# Troubleshooting

Please see our [troubleshooting guide](TROUBLESHOOTING.md) for common library issues.

# About

turboSMTP-csharp is maintained and funded by [Turbo SMTP][turboSMTP_about_us] Company. The names and logos for turboSMTP-csharp are trademarks of TurboSMTP Company.

# Support

If you need help using Turbo SMTP SDK, please check the [TurboSMTP Support Help Center][turboSMTP_contact_us].

# License

This SDK is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
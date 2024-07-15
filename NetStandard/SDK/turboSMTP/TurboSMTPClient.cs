using System.Configuration;
using TurboSMTP;
using TurboSMTP.Services;
using API.TurboSMTP.Client;
using Configuration = API.TurboSMTP.Client.Configuration;
using API.TurboSMTP.Model;
using System.Collections.Generic;

namespace TurboSMTP
{
    public class TurboSMTPClient
    {
        public readonly Suppressions Suppressions;
        public readonly EmailMessages Emails;
        public readonly EmailValidator emailValidator;
        public readonly EmailValidatorFiles EmailValidatorFiles;
        public readonly EmailValidatorFileResults EmailValidatorFileResults;
        public readonly Relays Relays;

        public TurboSMTPClient(TurboSMTPClientConfiguration configuration)
        {
            var APIConfiguration = new Configuration()
            {
                BasePath = configuration.ServerURL,
                DateTimeFormat = "yyyy-MM-dd",
                Servers = new List<IReadOnlyDictionary<string, object>>()
                {
                    {
                        new Dictionary<string, object> {
                            {"url", configuration.ServerURL},
                            {"description", ""},
                        }
                    }
                },
                OperationServers = new Dictionary<string, List<IReadOnlyDictionary<string, object>>>()
                {
                    {
                        "MailApi.SendEmail", new List<IReadOnlyDictionary<string, object>>
                        {
                            {
                                new Dictionary<string, object>
                                {
                                    {"url", configuration.SendServerURL },
                                    {"description", ""}
                                }
                            },
                        }
                    },
                }
            };
            APIConfiguration.AddApiKeyPrefix("consumerKey", configuration.ConsumerKey);
            APIConfiguration.AddApiKeyPrefix("consumerSecret", configuration.ConsumerSecret);

            GlobalConfiguration.Instance = APIConfiguration;

            this.Relays = new Relays(APIConfiguration,configuration.TimeZone);
            this.Emails = new EmailMessages(APIConfiguration);
            this.emailValidator = new EmailValidator(APIConfiguration, configuration.TimeZone);
            this.Suppressions = new Suppressions(APIConfiguration,configuration.TimeZone);
            this.EmailValidatorFiles = new EmailValidatorFiles(APIConfiguration, configuration.TimeZone);
            this.EmailValidatorFileResults = new EmailValidatorFileResults(APIConfiguration, configuration.TimeZone);
        }
    }
}

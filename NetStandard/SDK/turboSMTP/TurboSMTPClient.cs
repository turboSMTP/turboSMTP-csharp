using System.Configuration;
using TurboSMTP;
using TurboSMTPSDK.Services;
using API.TurboSMTP.Client;
using Configuration = API.TurboSMTP.Client.Configuration;
using API.TurboSMTP.Model;
using System.Collections.Generic;

namespace TurboSMTPSDK
{
    public class TurboSMTPClient
    {
        private readonly string ConsumerKey;
        private readonly string ConsumerSecret;

        public readonly Suppressions suppressions;
        public readonly Emails emails;
        public readonly EmailValidator emailValidator;
        public readonly Analytics analytics;

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

            this.analytics = new Analytics(APIConfiguration);
            this.emails = new Emails(APIConfiguration);
            this.emailValidator = new EmailValidator(APIConfiguration);
            this.suppressions = new Suppressions(APIConfiguration);
        }
    }
}

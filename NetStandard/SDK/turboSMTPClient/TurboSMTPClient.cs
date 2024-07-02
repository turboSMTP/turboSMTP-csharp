using System.Configuration;
using TurboSMTPSDK.Services;

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

        public TurboSMTPClient(string consumerKey, string consumerSecret)
        {
            this.ConsumerKey = consumerKey;
            this.ConsumerSecret = consumerSecret;

            this.suppressions = new Suppressions(this, consumerKey, consumerSecret);
            this.emails = new Emails(this, consumerKey, consumerSecret);
            this.emailValidator = new EmailValidator(this, consumerKey, consumerSecret);
            this.analytics = new Analytics(this, consumerKey, consumerSecret);
        }

        public TurboSMTPClient() : this(ConfigurationManager.AppSettings["consumerKey"], ConfigurationManager.AppSettings["consumerSecret"])
        {
            
        }
    }
}

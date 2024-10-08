using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace TurboSMTP
//{
//    public class TurboSMTPClientConfiguration
//    {
//        public string ConsumerKey { get; private set; }
//        public string ConsumerSecret { get; private set; }
//        public string ServerURL { get; private set; }

//        public string SendServerURL { get; private set; }

//        private TurboSMTPClientConfiguration() { }

//        public class Builder
//        {
//            private readonly TurboSMTPClientConfiguration _config = new TurboSMTPClientConfiguration();

//            public Builder SetConsumerKey(string consumerKey)
//            {
//                _config.ConsumerKey = consumerKey;
//                return this;
//            }

//            public Builder SetConsumerSecret(string consumerSecret)
//            {
//                _config.ConsumerSecret = consumerSecret;
//                return this;
//            }

//            public Builder SetServerURL(string serverURL)
//            {
//                _config.ServerURL = serverURL;
//                return this;
//            }

//            public Builder SetSendServerURL(string sendServerURL)
//            {
//                _config.SendServerURL = sendServerURL;
//                return this;
//            }

//            public TurboSMTPClientConfiguration Build()
//            {
//                // You can add validation here if needed
//                return _config;
//            }
//        }
//    }

//}


namespace TurboSMTP
{
    public class TurboSMTPClientConfiguration
    {
        // Private static instance for Singleton
        private static TurboSMTPClientConfiguration _instance;
        private static readonly object _lock = new object();

        // Public properties
        public string ConsumerKey { get; private set; }
        public string ConsumerSecret { get; private set; }
        public string ServerURL { get; private set; }
        public string SendServerURL { get; private set; }
        public string TimeZone { get; private set; } = default(string);

        // Private constructor to prevent direct instantiation
        private TurboSMTPClientConfiguration() { }

        // Static method to get the Singleton instance
        public static TurboSMTPClientConfiguration Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new TurboSMTPClientConfiguration();
                        }
                    }
                }
                return _instance;
            }
        }

        // Builder class
        public class Builder
        {
            private readonly TurboSMTPClientConfiguration _config;

            public Builder()
            {
                _config = TurboSMTPClientConfiguration.Instance;
            }

            public Builder SetConsumerKey(string consumerKey)
            {
                _config.ConsumerKey = consumerKey;
                return this;
            }

            public Builder SetConsumerSecret(string consumerSecret)
            {
                _config.ConsumerSecret = consumerSecret;
                return this;
            }

            public Builder SetServerURL(string serverURL)
            {
                _config.ServerURL = serverURL;
                return this;
            }

            public Builder SetSendServerURL(string sendServerURL)
            {
                _config.SendServerURL = sendServerURL;
                return this;
            }

            public Builder SetTimeZone(string timeZone)
            {
                _config.TimeZone = timeZone;
                return this;
            }

            public TurboSMTPClientConfiguration Build()
            {
                // You can add validation here if needed
                return _config;
            }
        }
    }
}
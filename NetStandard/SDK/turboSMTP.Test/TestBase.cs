using NUnit.Framework;
using System;
using TurboSMTP;

namespace turboSMTP.Test
{
    public abstract class TestBase
    {
        protected TurboSMTPClientConfiguration _InitalConfig;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            _InitalConfig = new TurboSMTPClientConfiguration.Builder()
                .SetConsumerKey(AppConstants.ConsumerKey)
                .SetConsumerSecret(AppConstants.ConsumerSecret)
                .SetServerURL(AppConstants.ServerUrl)
                .SetSendServerURL(AppConstants.SendServerUrl)
                .SetTimeZone("-03:00")
                .Build();
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {

        }

        public string GetFormatedDateTime()
        {
            return DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        public string GetFormatedDateTimeCompressed()
        {
            return DateTime.Now.ToString("ddMMyyyyHHmmss");
        }
    }
}

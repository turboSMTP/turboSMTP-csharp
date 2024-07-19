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
                .SetConsumerKey("1ef0eef86f089b18cb610532beecf72e")
                .SetConsumerSecret("GIx7Z0OncXf9oANe8z3gUQ6wYPtJH21d")
                .SetServerURL("https://staging.api.serversmtp.com/api/v2")
                .SetSendServerURL("https://api.turbo-smtp.com/api/v2")
                .SetTimeZone("-03:00")
                .Build();
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {

        }

        public string GetFormatedDateTime()
        {
            return DateTime.Now.ToString("dd/MM/YYYY HH:mm:ss");
        }

        public string GetFormatedDateTimeCompressed()
        {
            return DateTime.Now.ToString("ddMMYYYYHHmmss");
        }
    }
}

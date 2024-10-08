using System.Collections.Generic;

namespace turboSMTP.Test
{
    internal static class AppConstants
    {
        public static readonly string ConsumerKey = "ConsumerKey";
        public static readonly string ConsumerSecret = "ConsumerSecret";

        public static readonly string ServerUrl = "https://pro.api.serversmtp.com/api/v2";
        public static readonly string SendServerUrl = "https://api.turbo-smtp.com/api/v2";

        public static readonly string EmailSender = "emailsender";
        public static readonly List<string> ValidEmailAddresses = new List<string>()
        {
            "live@service.alibaba.com",
            "live@service.alibaba.com"
        };
        public static readonly List<string> InvalidEmailAddresses = new List<string>()
        {
            "random-guid-9981D02A-AE85-448C-B4FB-A4F70339FD18@gmail.com",
            "random-guid-07B776E0-B891-48E9-AFF2-6548A3470934@gmail.com"
        };
    }
}

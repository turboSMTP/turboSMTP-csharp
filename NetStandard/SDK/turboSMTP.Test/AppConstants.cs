using System.Collections.Generic;

namespace turboSMTP.Test
{
    internal static class AppConstants
    {
        public static readonly string EmailSender = "msaad@emailchef.com";
        public static readonly List<string> ValidEmailAddresses = new List<string>()
        {
            "sergio.a.matteoda@gmail.com",
            "sergio.test2@turbo-smtp.com"
        };
        public static readonly List<string> InvalidEmailAddresses = new List<string>()
        {
            "random-guid-9981D02A-AE85-448C-B4FB-A4F70339FD18@gmail.com",
            "random-guid-07B776E0-B891-48E9-AFF2-6548A3470934@gmail.com"
        };
    }
}

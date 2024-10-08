using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboSMTP.Services
{
    public abstract class EmailValidatorBase
    {
        protected IEmailValidatorApiAsync API;
        protected String TimeZone = "00:00";

        private EmailValidatorBase()
        {

        }

        public EmailValidatorBase(Configuration configuration, string timeZone)
        {
            API = new EmailValidatorApi(configuration);
            TimeZone = timeZone;
        }
    }
}

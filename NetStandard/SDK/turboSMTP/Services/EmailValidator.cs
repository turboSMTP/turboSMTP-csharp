using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TurboSMTP.Domain;
using TurboSMTP.Model.EmailValidator;
using TurboSMTP.Model.Shared;
using EmailValidatorSubscription = TurboSMTP.Domain.EmailValidatorSubscription;

namespace TurboSMTP.Services
{
    public class EmailValidator : EmailValidatorBase
    {
        public EmailValidator(Configuration configuration, string timeZone) : base(configuration,timeZone) {}

        public async Task<EmailValidatorSubscription> GetEmailValidatorSubscription()
        {
            var response = await API.GetEmailValidationSubscriptionAsync();
            return new EmailValidatorSubscription(
                response.Currency,
                response.FreeCredits,
                response.FreeCreditsUsed,
                response.LastUsedPeriod,
                response.LatestPeriodStartDate,
                response.PeriodExpirationDate,
                response.PaidCredits,
                response.RemainingFreeCredit);
        }

        public async Task<EmailAddressValidationDetails> Validate(string email)
        {
            try
            {
                var res = await API.ValidateEmailAsync(new EmailAddressRequestBody() { Email = email});
                return new EmailAddressValidationDetails(
                   res.Email,
                   (EmailAddressValidationDetails.EmailAddressValidationStatus)res.Status,
                   res.SubStatus.HasValue ? (EmailAddressValidationDetails.EmailAddressValidationSubStatus)res.SubStatus : default(EmailAddressValidationDetails.EmailAddressValidationSubStatus?),
                   res.FreeEmail,
                   res.Domain,
                   res.DomainAgeDays,
                   res.SmtpProvider,
                   res.MxFound,
                   res.MxRecord,
                   0);
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}

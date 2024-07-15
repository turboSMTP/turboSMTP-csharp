using API.TurboSMTP.Client;
using System.Linq;
using System.Threading.Tasks;
using TurboSMTP.Model.EmailValidator;
using TurboSMTP.Model.Shared;

namespace TurboSMTP.Services
{
    public class EmailValidatorFileResults : EmailValidatorBase
    {
        public EmailValidatorFileResults(Configuration configuration, string timeZone) : base(configuration, timeZone){}

        public async Task<PagedListResults<EmailAddressValidationDetails>> GetEmailValidationDetailsByList(EmailValidatorFileResultsQueryOptions options)
        {
            var response = await API.GetValidatedEmailsByListAsync(options.FileId,options.Page, options.Limit);
            
            return new PagedListResults<EmailAddressValidationDetails>()
            {
                TotalRecords = response.Results.Count,
                Records = response.Results.Select(r => new EmailAddressValidationDetails(
                   r.Email,
                   (EmailAddressValidationDetails.EmailAddressValidationStatus)r.Status,
                   r.SubStatus.HasValue ? (EmailAddressValidationDetails.EmailAddressValidationSubStatus)r.SubStatus : default(EmailAddressValidationDetails.EmailAddressValidationSubStatus?),
                   r.FreeEmail,
                   r.Domain,
                   r.DomainAgeDays,
                   r.SmtpProvider,
                   r.MxFound,
                   r.MxRecord,
                   r.Id)).ToList()
            };
        }

        public async Task<string> Export(int id)
        {
            var response = await API.ExportCSVValidatedEmailsByListAsync(id);
            return response;
        }

    }
}

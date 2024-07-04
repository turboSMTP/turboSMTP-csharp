using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TurboSMTPSDK.Model.EmailValidator;
using TurboSMTPSDK.Model.Shared;
using File = TurboSMTPSDK.Model.EmailValidator.File;

namespace TurboSMTPSDK.Services
{
    public sealed class EmailValidator
    {
        IEmailValidatorApiAsync API;

        private EmailValidator()
        {
            
        }
        private readonly TurboSMTPClient turboSMTP;

        public EmailValidator(Configuration configuration)
        {
            API = new EmailValidatorApi(configuration);
        }

        public async Task<Subscription> Subscription()
        {
            var response = await API.GetEmailValidationSubscriptionAsync();
            return new Subscription(
                response.Currency,
                response.FreeCredits,
                response.FreeCreditsUsed,
                response.LastUsedPeriod,
                response.LatestPeriodStartDate,
                response.PeriodExpirationDate,
                response.PaidCredits,
                response.RemainingFreeCredit);
        }

        private PagedListResults<File> GetPagedListResults(EmailValidatorSucessResponsetBody response)
        {
            return new PagedListResults<File>()
            {
                TotalRecords = response.Count,
                Records = response.Results.Select(r => new File(
                    r.Id,
                    r.CreationTime,
                    r.FileName,
                    r.IsProcessed,
                    r.Percentage,
                    r.TotalEmails,
                    r.TotalProcessed)).ToList()
            };
        }

        private PagedListResults<EmailAddressDetails> GetPagedListResults(EmailValidatorValidatedMailsResults response)
        {
            return new PagedListResults<EmailAddressDetails>()
            {
                TotalRecords = response.Results.Count,
                Records = response.Results.Select(r => new EmailAddressDetails(
                   r.Email,
                   (EmailAddressDetails.StatusEnum)r.Status,
                   r.SubStatus.HasValue ? (EmailAddressDetails.SubStatusEnum)r.SubStatus : default(EmailAddressDetails.SubStatusEnum?),
                   r.FreeEmail,
                   r.Domain,
                   r.DomainAgeDays,
                   r.SmtpProvider,
                   r.MxFound,
                   r.MxRecord,
                   r.Id)).ToList()
            };

        }


        public async Task<PagedListResults<File>> List(DateTime from, DateTime to)
        {
            return await List(from, to, new ListOptions());
        }

        public async Task<PagedListResults<File>> List(DateTime from, DateTime to, ListOptions options)
        {

            var response = await API.GetEmailValidationListsAsync(
                from,
                to,
                options.page,
                options.limit,
                options.tz);

            return GetPagedListResults(response);
        }

        public async Task<File> Get(int id)
        {
            try
            {
                var result = await API.GetEmailValidationListSummaryAsync(id);
                return new File(
                        result.Id,
                        result.CreationTime,
                        result.FileName,
                        result.IsProcessed,
                        result.Percentage,
                        result.TotalEmails,
                        result.TotalProcessed);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<Boolean> Delete(int id)
        {
            try
            {
                var result = await API.DeleteEmailValidationListByIdAsync(id);
                return result.Success;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<int> AddFile(string filename, List<string> emailAddresses)
        {
            string tempFolderPath = Path.Combine(Path.GetTempPath(), "TSSDK");
            EmailValidationUploadResponse res;

            if (!Directory.Exists(tempFolderPath))
            {
                Directory.CreateDirectory(tempFolderPath);
            }

            string filePath = Path.Combine(tempFolderPath, filename);

            System.IO.File.WriteAllLines(filePath, emailAddresses);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                res = await API.UploadEmailValidationFileAsync(fileStream);
                fileStream.Close();
            }

            System.IO.File.Delete(filePath);
            //Directory.Delete(tempFolderPath);

            return res.ListId;
        }

        public async Task<PagedListResults<EmailAddressDetails>> GetEmailValidationDetailsByList(int listId)
        {
            var response = await GetEmailValidationDetailsByList(listId, new PageListOptions());
            return response;
        }

        public async Task<PagedListResults<EmailAddressDetails>> GetEmailValidationDetailsByList(int listId, PageListOptions pageListOptions)
        {
            var response = await API.GetValidatedEmailsByListAsync(listId, pageListOptions.page, pageListOptions.limit);
            return GetPagedListResults(response);
        }

        public async Task<EmailAddressDetails> GetEmailValidationDetailsByEmailId(int listId, int emailId)
        {
            var result = await API.GetEmailValidationDataByEmailIdAsync(listId, emailId);
            return new EmailAddressDetails(
                   result.Email,
                   (EmailAddressDetails.StatusEnum)result.Status,
                   result.SubStatus.HasValue ? (EmailAddressDetails.SubStatusEnum)result.SubStatus : default(EmailAddressDetails.SubStatusEnum?),
                   result.FreeEmail,
                   result.Domain,
                   result.DomainAgeDays,
                   result.SmtpProvider,
                   result.MxFound,
                   result.MxRecord,
                   result.Id);
        }

        public async Task<Boolean> Validate(int id)
        {
            try
            {
                await API.ValidateEmailValidatorListAsync(id);
                var result = await API.GetValidatedEmailsByListAsync(id);
                while (result.Processed<result.Count) 
                {
                    Thread.Sleep(1000);
                    result = await API.GetValidatedEmailsByListAsync(id);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<Boolean> Validate(string email)
        {
            try
            {
                var res = await API.ValidateEmailAsync(new EmailAddressRequestBody() { Email = email});
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<string> Export(int id)
        {
            var response = await API.ExportCSVValidatedEmailsByListAsync(id);
            return response;
        }

    }
}

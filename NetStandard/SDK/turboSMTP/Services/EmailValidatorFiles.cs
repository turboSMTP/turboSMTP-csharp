using API.TurboSMTP.Client;
using API.TurboSMTP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TurboSMTP.Domain;
using TurboSMTP.Model.EmailValidator;
using TurboSMTP.Model.Shared;

namespace TurboSMTP.Services
{
    public sealed class EmailValidatorFiles : EmailValidatorBase
    {
        public EmailValidatorFiles(Configuration configuration, string timeZone) : base(configuration,timeZone) {}

        public async Task<int> AddAsync(string filename, List<string> emailAddresses)
        {
            if (emailAddresses == null || emailAddresses.Count==0) { throw new ArgumentException("emailAddress"); }
            
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

        public async Task<PagedListResults<EmailValidatorFile>> QueryAsync(EmailValidatorFilesQueryOptions options)
        {

            var response = await API.GetEmailValidationListsAsync(
                options.From,
                options.To,
                options.Page,
                options.Limit,
                TimeZone);

            return new PagedListResults<EmailValidatorFile>()
            {
                TotalRecords = response.Count,
                Records = response.Results.Select(r => new EmailValidatorFile(
                    r.Id,
                    r.CreationTime,
                    r.FileName,
                    r.IsProcessed,
                    r.Percentage,
                    r.TotalEmails,
                    r.TotalProcessed)).ToList()
            };
        }

        public async Task<EmailValidatorFile> GetAsync(int id)
        {
            try
            {
                var result = await API.GetEmailValidationListSummaryAsync(id);
                return new EmailValidatorFile(
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

        public async Task<Boolean> DeleteAsync(int id)
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

        public async Task<Boolean> ValidateAsync(int id)
        {
            try
            {
                await API.ValidateEmailValidatorListAsync(id);
                var result = await API.GetValidatedEmailsByListAsync(id);
                while (result.Processed < result.Count)
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
    }
}

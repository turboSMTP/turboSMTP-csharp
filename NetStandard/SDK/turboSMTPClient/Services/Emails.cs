using API.TurboSMTP.Api;
using API.TurboSMTP.Model;
using System.Linq;
using System.Threading.Tasks;
using TurboSMTPSDK.Model.Extensions;
using Email = TurboSMTPSDK.Model.Email.Email;

namespace TurboSMTPSDK.Services
{
    public sealed class Emails
    {
        private Emails()
        {
            
        }
        private readonly TurboSMTPClient turboSMTP;
        IMailApiAsync API;
        public Emails(TurboSMTPClient turboSMTP, string consumerkey, string consumerSecret)
        {
            this.turboSMTP = turboSMTP;
            var config = new API.TurboSMTP.Client.Configuration();
            config.AddApiKeyPrefix("consumerKey", consumerkey);
            config.AddApiKeyPrefix("consumerSecret", consumerSecret);
            API = new MailApi(config);
        }

        public async Task<SendSucessResponsetBody> Send(Email email)
        {
            var emailRequest = new EmailRequestBody()
            {
                From = email.From,
                To = email.To.ToCommaSeparated(),
                Subject = email.Subject,
                Cc = email.Cc.ToCommaSeparated(),
                Bcc = email.Bcc.ToCommaSeparated(),
                Content = email.Content,
                HtmlContent = email.HtmlContent,
                CustomHeaders = email.CustomHeaders,
                ReferenceId = email.ReferenceId,
                MimeRaw = email.MimeRaw,
                Attachments = email.Attachments.Select(a =>
                    new API.TurboSMTP.Model.Attachment(a.Content, a.Name, a.Type))
                    .ToList(),
            };
            return await API.SendEmailAsync(emailRequest);
        }
    }
}

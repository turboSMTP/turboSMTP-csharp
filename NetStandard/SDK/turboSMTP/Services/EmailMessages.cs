using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using TurboSMTP.Domain;
using TurboSMTP.Model.Extensions;

namespace TurboSMTP.Services
{
    public sealed class EmailMessages
    {
        IMailApiAsync API;

        private EmailMessages()
        {
            
        }

        public EmailMessages(Configuration configuration)
        {
            API = new MailApi(configuration);
        }

        public async Task<SendSucessResponsetBody> Send(EmailMessage email)
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
                XCampaignID = email.CampaignID,
                Attachments = email.Attachments.Select(a =>
                    new API.TurboSMTP.Model.Attachment(a.Content, a.Name, a.Type))
                    .ToList(),
            };
            return await API.SendEmailAsync(emailRequest);
        }
    }
}

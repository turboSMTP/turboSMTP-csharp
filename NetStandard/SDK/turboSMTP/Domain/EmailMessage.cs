using System.Collections.Generic;
using System.Text;

namespace TurboSMTP.Domain
{
    public sealed class EmailMessage
    {
        private EmailMessage() { }

        // Properties
        public string From { get; private set; }
        public List<string> To { get; private set; }
        public string Subject { get; private set; }
        public List<string> Cc { get; private set; }
        public List<string> Bcc { get; private set; }
        public string Content { get; private set; }
        public string HtmlContent { get; private set; }
        public Dictionary<string, string> CustomHeaders { get; private set; }
        public string ReferenceId { get; private set; }
        public string MimeRaw { get; private set; }
        public List<EmailAttachment> Attachments { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EmailMessage {\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  To: ").Append(string.Join(", ", To)).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  Cc: ").Append(string.Join(", ", Cc)).Append("\n");
            sb.Append("  Bcc: ").Append(string.Join(", ", Bcc)).Append("\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  HtmlContent: ").Append(HtmlContent).Append("\n");
            sb.Append("  CustomHeaders: ").Append(CustomHeaders).Append("\n");
            sb.Append("  ReferenceId: ").Append(ReferenceId).Append("\n");
            sb.Append("  MimeRaw: ").Append(MimeRaw).Append("\n");
            sb.Append("  Attachments: ").Append(string.Join(", ", Attachments)).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        // Nested Builder Class
        public class Builder
        {
            private readonly EmailMessage _emailMessage;

            public Builder()
            {
                _emailMessage = new EmailMessage
                {
                    To = new List<string>(),
                    Cc = new List<string>(),
                    Bcc = new List<string>(),
                    CustomHeaders = new Dictionary<string, string>(),
                    Attachments = new List<EmailAttachment>()
                };
            }

            public Builder SetFrom(string from)
            {
                _emailMessage.From = from;
                return this;
            }

            public Builder AddTo(string to)
            {
                _emailMessage.To.Add(to);
                return this;
            }

            public Builder SetSubject(string subject)
            {
                _emailMessage.Subject = subject;
                return this;
            }

            public Builder AddCc(string cc)
            {
                _emailMessage.Cc.Add(cc);
                return this;
            }

            public Builder AddBcc(string bcc)
            {
                _emailMessage.Bcc.Add(bcc);
                return this;
            }

            public Builder SetContent(string content)
            {
                _emailMessage.Content = content;
                return this;
            }

            public Builder SetHtmlContent(string htmlContent)
            {
                _emailMessage.HtmlContent = htmlContent;
                return this;
            }

            public Builder AddCustomHeader(string key, string value)
            {
                _emailMessage.CustomHeaders[key] = value;
                return this;
            }

            public Builder SetReferenceId(string referenceId)
            {
                _emailMessage.ReferenceId = referenceId;
                return this;
            }

            public Builder SetMimeRaw(string mimeRaw)
            {
                _emailMessage.MimeRaw = mimeRaw;
                return this;
            }

            public Builder AddAttachment(EmailAttachment attachment)
            {
                _emailMessage.Attachments.Add(attachment);
                return this;
            }

            private void Validate()
            {

            }

            public EmailMessage Build()
            {
                Validate();
                return _emailMessage;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboSMTPSDK.Model.Email
{
    public sealed class Email
    {
        private Email() { }
        public Email
            (
            string from = default(string), 
            List<string> to = default(List<string>), 
            string subject = default(string), 
            List<string> cc = default(List<string>), 
            List<string> bcc = default(List<string>), 
            string content = default(string), 
            string htmlContent = default(string), 
            Dictionary<string, string> customHeaders = default(Dictionary<string, string>), 
            string referenceId = default(string), 
            string mimeRaw = default(string), 
            List<Attachment> attachments = default(List<Attachment>))
        {
            this.From = from;
            this.To = to;
            this.Subject = subject;
            this.Cc = cc;
            this.Bcc = bcc;
            this.Content = content;
            this.HtmlContent = htmlContent;
            this.CustomHeaders = customHeaders;
            this.ReferenceId = referenceId;
            this.MimeRaw = mimeRaw;
            this.Attachments = attachments == null? new List<Attachment>() : attachments;
        }

        public string From { get; set; }
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public List<string> Cc { get; set; }
        public List<string> Bcc { get; set; }
        public string Content { get; set; }
        public string HtmlContent { get; set; }
        public Dictionary<string, string> CustomHeaders { get; set; }
        public string ReferenceId { get; set; }
        public string MimeRaw { get; set; }
        public List<Attachment> Attachments { get; set; } = new List<Attachment>();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EmailRequestBody {\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  Cc: ").Append(Cc).Append("\n");
            sb.Append("  Bcc: ").Append(Bcc).Append("\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  HtmlContent: ").Append(HtmlContent).Append("\n");
            sb.Append("  CustomHeaders: ").Append(CustomHeaders).Append("\n");
            sb.Append("  ReferenceId: ").Append(ReferenceId).Append("\n");
            sb.Append("  MimeRaw: ").Append(MimeRaw).Append("\n");
            sb.Append("  Attachments: ").Append(Attachments).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }


    }
}

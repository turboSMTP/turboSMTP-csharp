using System;
using System.Text;
using TurboSMTPSDK.Model.Extensions;

namespace TurboSMTPSDK.Model.Suppressions
{
    public sealed class Suppression
    {
        private Suppression() { }
        public Suppression(string date = default(string), string sender = default(string), Source? source = default(Source?), string subject = default(string), string recipient = default(string), string reason = default(string))
        {
            this.Date = date.FromTSDatetimes();
            this.Sender = sender;
            this.Source = source;
            this.Subject = subject;
            this.Recipient = recipient;
            this.Reason = reason;
        }
        public Source? Source { get; set; }
        public DateTime Date { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Recipient { get; set; }
        public string Reason { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Suppression {\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  Sender: ").Append(Sender).Append("\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  Recipient: ").Append(Recipient).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }

}

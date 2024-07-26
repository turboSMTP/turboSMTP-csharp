using System.Text;

namespace TurboSMTP.Domain
{
    public sealed class Relay
    {
        private Relay()
        {
                
        }
        public Relay(
            long messageID = default(long), 
            string subject = default(string), 
            string sender = default(string), 
            string recipient = default(string), 
            string sendTime = default(string), 
            RelayStatus? status = default(RelayStatus?), 
            string domain = default(string), 
            string contactDomain = default(string), 
            string error = default(string),
            string xCampaignId = default(string))
        {
            this.MessageID = messageID;
            this.Subject = subject;
            this.Sender = sender;
            this.Recipient = recipient;
            this.SendTime = sendTime;
            this.Status = status;
            this.Domain = domain;
            this.ContactDomain = contactDomain;
            this.Error = error;
            this.XCampaignId = xCampaignId;
        }
        public RelayStatus? Status { get; set; }
        public long MessageID { get; set; }
        public string Subject { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string SendTime { get; set; }
        public string Domain { get; set; }
        public string ContactDomain { get; set; }
        public string Error { get; set; }

        public string XCampaignId { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Analytic {\n");
            sb.Append("  MessageID: ").Append(MessageID).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  Sender: ").Append(Sender).Append("\n");
            sb.Append("  Recipient: ").Append(Recipient).Append("\n");
            sb.Append("  SendTime: ").Append(SendTime).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Domain: ").Append(Domain).Append("\n");
            sb.Append("  ContactDomain: ").Append(ContactDomain).Append("\n");
            sb.Append("  Error: ").Append(Error).Append("\n");
            sb.Append("  XCampaignId: ").Append(XCampaignId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}

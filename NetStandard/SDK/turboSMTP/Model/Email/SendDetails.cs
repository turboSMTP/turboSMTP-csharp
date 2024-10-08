using System.Text;

namespace TurboSMTP.Model.Email
{
    public class SendDetails
    {
        public SendDetails(string message = default(string), long mid = default(long))
        {
            this.Message = message;
            this.MessageID = mid;
        }
        public string Message { get; set; }
        public long MessageID { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SendSucessResponsetBody {\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  MessageID: ").Append(MessageID).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }

}

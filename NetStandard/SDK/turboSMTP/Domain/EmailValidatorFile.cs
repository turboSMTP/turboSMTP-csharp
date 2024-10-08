using System;
using System.Text;
using TurboSMTP.Model.Extensions;

namespace TurboSMTP.Domain
{
    public sealed class EmailValidatorFile
    {
        private EmailValidatorFile() { }
        public EmailValidatorFile(int id = default(int), string creationTime = default(string), string fileName = default(string), bool isProcessed = default(bool), int percentage = default(int), int totalEmails = default(int), int totalProcessed = default(int))
        {
            this.Id = id;
            this.CreationTime = creationTime.FromTSDatetimes();
            this.FileName = fileName;
            this.IsProcessed = isProcessed;
            this.Percentage = percentage;
            this.TotalEmails = totalEmails;
            this.TotalProcessed = totalProcessed;
        }
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string FileName { get; set; }
        public bool IsProcessed { get; set; }
        public int Percentage { get; set; }
        public int TotalEmails { get; set; }
        public int TotalProcessed { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class File {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CreationTime: ").Append(CreationTime).Append("\n");
            sb.Append("  FileName: ").Append(FileName).Append("\n");
            sb.Append("  IsProcessed: ").Append(IsProcessed).Append("\n");
            sb.Append("  Percentage: ").Append(Percentage).Append("\n");
            sb.Append("  TotalEmails: ").Append(TotalEmails).Append("\n");
            sb.Append("  TotalProcessed: ").Append(TotalProcessed).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}

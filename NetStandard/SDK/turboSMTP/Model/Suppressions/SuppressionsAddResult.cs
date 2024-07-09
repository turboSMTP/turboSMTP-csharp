using System.Collections.Generic;
using System.Text;

namespace TurboSMTP.Model.Suppressions
{
    public sealed class SuppressionsAddResult
    {
        private SuppressionsAddResult() { }
        public SuppressionsAddResult(string status = default(string), List<string> valid = default(List<string>), List<string> invalid = default(List<string>))
        {
            this.Status = status;
            this.Valid = valid;
            this.Invalid = invalid;
        }
        public string Status { get; set; }
        public List<string> Valid { get; set; }
        public List<string> Invalid { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SuppressionUploadResponse {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Valid: ").Append(Valid).Append("\n");
            sb.Append("  Invalid: ").Append(Invalid).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}

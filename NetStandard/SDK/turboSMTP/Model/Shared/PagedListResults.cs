using System.Collections.Generic;
using System.Text;

namespace TurboSMTP.Model.Shared
{
    public sealed class PagedListResults<T>
    {
        private PagedListResults() { }
        public PagedListResults(int count = default(int), List<T> results = default(List<T>))
        {
            this.TotalRecords = count;
            this.Records = results;
        }

        public int TotalRecords { get; set; }
        public List<T> Records { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SuppressionsSucessResponsetBody {\n");
            sb.Append("  Count: ").Append(TotalRecords).Append("\n");
            sb.Append("  Results: ").Append(Records).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}

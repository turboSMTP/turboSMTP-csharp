using System.Linq;
using System.Text;

namespace TurboSMTP.Model.Suppressions
{
    public sealed class SuppressionsRestriction
    {
        private SuppressionsRestriction() { }
        public SuppressionsRestriction(SuppresionsRestrictionFilterBy? by = default(SuppresionsRestrictionFilterBy?), SuppressionsRestrictionOperator? varOperator = default(SuppressionsRestrictionOperator?), string filter = default(string), bool? smartSearch = false)
        {
            this.By = by;
            this.Operator = varOperator;
            this.Filter = filter;
            // use default value if no "smartSearch" provided
            this.SmartSearch = smartSearch ?? false;
        }
        public SuppresionsRestrictionFilterBy? By { get; set; }
        public SuppressionsRestrictionOperator? Operator { get; set; }

        public string Filter { get; set; }
        public bool? SmartSearch { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SuppressionRestriction {\n");
            sb.Append("  By: ").Append(By).Append("\n");
            sb.Append("  VarOperator: ").Append(Operator).Append("\n");
            sb.Append("  Filter: ").Append(Filter).Append("\n");
            sb.Append("  SmartSearch: ").Append(SmartSearch).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}


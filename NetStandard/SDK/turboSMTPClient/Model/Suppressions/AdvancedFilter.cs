using System.Linq;
using System.Text;

namespace TurboSMTPSDK.Model.Suppressions
{
    public sealed class AdvancedFilter
    {
        private AdvancedFilter() { }
        public AdvancedFilter(AdvancedFilterBy? by = default(AdvancedFilterBy?), AdvancedFilterOperator? varOperator = default(AdvancedFilterOperator?), string filter = default(string), bool? smartSearch = false)
        {
            this.By = by;
            this.Operator = varOperator;
            this.Filter = filter;
            // use default value if no "smartSearch" provided
            this.SmartSearch = smartSearch ?? false;
        }
        public AdvancedFilterBy? By { get; set; }
        public AdvancedFilterOperator? Operator { get; set; }

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


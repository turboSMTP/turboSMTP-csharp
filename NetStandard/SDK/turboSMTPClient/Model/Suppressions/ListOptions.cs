using System.Collections.Generic;
using TurboSMTPSDK.Model.Shared;

namespace TurboSMTPSDK.Model.Suppressions
{
    public sealed class ListOptions : PageListOptions
    {
        public string tz { get; set; } = default(string);
        public string filter { get; set; } = default(string);
        public List<Source> filterBy { get; set; } = default(List<Source>);
        public bool? smartSearch { get; set; } = default(bool?);
        public OrderBy orderby { get; set; } = OrderBy.Date;
        public OrderType ordertype { get; set; } = OrderType.Desc;
    }
}

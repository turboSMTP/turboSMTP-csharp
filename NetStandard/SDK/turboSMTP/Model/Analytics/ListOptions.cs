using System.Collections.Generic;
using TurboSMTPSDK.Model.Shared;

namespace TurboSMTPSDK.Model.Analytics
{
    public sealed class ListOptions : PageListOptions
    {
        public string tz { get; set; } = default(string);
        public List<MailStatus> MailStatuses = default(List<MailStatus>);
        public List<FilterCriteria> filterBy { get; set; } = default(List<FilterCriteria>);
        public string filter { get; set; } = default(string);
        public bool? smartSearch { get; set; } = default(bool?);
        public OrderBy orderby { get; set; } = OrderBy.SendTime;
        public OrderType ordertype { get; set; } = OrderType.Desc;
    }
}

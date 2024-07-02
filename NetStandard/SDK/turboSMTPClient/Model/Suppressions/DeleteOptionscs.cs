using System.Collections.Generic;

namespace TurboSMTPSDK.Model.Suppressions
{
    public sealed class DeleteOptions
    {
        public string tz { get; set; } = default(string);
        public string filter { get; set; } = default(string);
        public List<Source> filterBy { get; set; } = default(List<Source>);
        public bool? smartSearch { get; set; } = default(bool?);
    }
}

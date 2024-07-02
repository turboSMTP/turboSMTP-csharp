using TurboSMTPSDK.Model.Shared;

namespace TurboSMTPSDK.Model.EmailValidator
{
    public sealed class ListOptions : PageListOptions
    {
        public string tz { get; set; } = default(string);
    }
}

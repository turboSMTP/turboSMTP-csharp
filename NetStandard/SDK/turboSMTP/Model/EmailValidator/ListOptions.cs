using TurboSMTP.Model.Shared;

namespace TurboSMTP.Model.EmailValidator
{
    public sealed class ListOptions : PageListOptions
    {
        public string tz { get; set; } = default(string);
    }
}

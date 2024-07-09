namespace TurboSMTP.Model.Shared
{
    public class PageListOptions
    {
        public int? page { get; set; } = default(int?);
        public int? limit { get; set; } = default(int?);
    }
}

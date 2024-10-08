namespace TurboSMTP.Model.Shared
{
    public interface IPagingOptions
    {
        int? Page { get; }
        int? Limit { get; }
    }
}

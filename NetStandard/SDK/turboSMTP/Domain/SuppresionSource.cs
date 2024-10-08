namespace TurboSMTP.Domain
{
    public enum SuppresionSource
    {
        Manual = 1,
        Bounce = 2,
        Spam = 3,
        Unsubscribe = 4,
        ValidationFailed = 5
    }
}

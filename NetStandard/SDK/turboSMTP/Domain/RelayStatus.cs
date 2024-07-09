namespace TurboSMTP.Domain
{
    public enum RelayStatus
    {
        NEW = 1,
        DEFER = 2,
        SUCCESS = 3,
        OPEN = 4,
        CLICK = 5,
        REPORT = 6,
        FAIL = 7,
        SYSFAIL = 8,
        UNSUB = 9
    }

}

using System;

namespace TurboSMTP.Model.Shared
{
    public interface IDateRange
    {
        DateTime From { get; }
        DateTime To { get; }
    }
}

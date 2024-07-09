using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboSMTP.Model.Shared
{
    public interface IDateRange
    {
        DateTime From { get; }
        DateTime To { get; }
    }
}

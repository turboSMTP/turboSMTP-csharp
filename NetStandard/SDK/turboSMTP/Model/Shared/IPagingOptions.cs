using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboSMTP.Model.Shared
{
    public interface IPagingOptions
    {
        int? Page { get; }
        int? Limit { get; }
    }
}

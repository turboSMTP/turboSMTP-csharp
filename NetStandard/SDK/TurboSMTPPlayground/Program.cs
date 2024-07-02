using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboSMTPSDK;
using TurboSMTPSDK.Suppressions;

namespace TSPlayground
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var TS = new TurboSMTP("0f04c8c577f789d12a7e85e9ef7d23d9", "lGC5Lktrpi1N8AHm4KQdwnYJ9bSZ6ORX");
            var res = await TS.suppressions.List(
                1,
                DateTime.Now.AddYears(-3),
                DateTime.Now,
                new SuppressionsListOptions()
                {
                    limit = 100
                });
            Console.WriteLine(res);
        }
    }
}

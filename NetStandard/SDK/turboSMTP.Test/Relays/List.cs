using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using turboSMTP.Test;
using TurboSMTP.Model.Relays;

namespace TurboSMTP.Test.Relays
{
    public class List : TestBase
    {
        [Test]
        public async Task Query_Relays_With_Default_Params()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            var queryOptions = new RelaysQueryOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .Build();
                
            //Act
            try
            {
                var result = await TS.Relays.Query(queryOptions);
                //Assert
                Assert.That(result.Records.Count <= 10);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }

        [Test]
        public async Task Query_Relays_Whith_Limit()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            var queryOptions = new RelaysQueryOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .SetLimit(5)
                .Build();
            //Act
            var result = await TS.Relays.Query(queryOptions);
            //Assert
            Assert.That(result.Records.Count <= queryOptions.Limit,$"Limit = {queryOptions.Limit} - Returned results = {result.TotalRecords}");
            Assert.Pass();
        }

        [Test]
        public async Task Query_Relays_Filtered_By_Subject()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            var queryOptions = new RelaysQueryOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .SetLimit(1000)
                .SetFilterBy(new[] { RelayFilterCriteria.Subject })
                .SetFilter("team")
                .Build();
            //Act
            var result = await TS.Relays.Query(queryOptions);
            //Assert
            Assert.That(result.Records.All(s => s.Subject.Contains(queryOptions.Filter)));
            Assert.Pass();
        }


    }
}

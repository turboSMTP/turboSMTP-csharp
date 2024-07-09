using NUnit.Framework;
using System;
using System.Threading.Tasks;
using turboSMTP.Test;
using TurboSMTP.Model.Relays;

namespace TurboSMTP.Test.Relays
{
    public class Export: TestBase
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task Export_Relays_With_Default_Params()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            var queryOptions = new RelaysExportOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .Build();
            //Act
            try
            {
                var result = await TS.Relays.Export(queryOptions);
                //Assert
                Assert.That(result.Length>0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }

        [Test]
        public async Task Export_Relays_Filtered_By_Subject()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            var queryOptions = new RelaysExportOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .SetFilterBy(new[] { RelayFilterCriteria.Subject })
                .SetFilter("test")
                .Build();

            //Act
            var result = await TS.Relays.Export(queryOptions);
            //Assert
            Assert.That(result.Length > 0);
            Assert.That(result.Contains(queryOptions.Filter));
            Assert.Pass();
        }
    }
}

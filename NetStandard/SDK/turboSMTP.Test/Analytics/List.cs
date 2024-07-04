using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using turboSMTP.Test;
using TurboSMTP;
using TurboSMTPSDK.Model.Analytics;

namespace TurboSMTPSDK.Test.Analytics
{
    public class List : TestBase
    {
        [Test]
        [Description("Will Retrieve Analytics for last 3 years")]
        public async Task Retrieve_Analytics_With_Default_Params()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            //Act
            try
            {
                var result = await TS.analytics.List(
                    DateTime.Now.AddYears(-3),
                    DateTime.Now);
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
        public async Task Retrieve_Analytics_Whith_Limit()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            var limit = 5;
            //Act
            var result = await TS.analytics.List(
                DateTime.Now.AddYears(-3),
                DateTime.Now,
                new ListOptions()
                {
                    limit = limit
                });
            //Assert
            Assert.That(result.Records.Count <= limit,$"Limit = {limit} - Returned results = {result.TotalRecords}");
            Assert.Pass();
        }

        [Test]
        public async Task Retrieve_Analytics_Filtered_By_Subject()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            var keyWord = "team";
            //Act
            var result = await TS.analytics.List(
                DateTime.Now.AddYears(-3),
                DateTime.Now,
                new ListOptions()
                {
                    limit = 1000,
                    filterBy = new[] { FilterCriteria.Subject }.ToList(),
                    filter = keyWord
                }
                );
            //Assert
            Assert.That(result.Records.All(s => s.Subject.Contains(keyWord)));
            Assert.Pass();
        }


    }
}

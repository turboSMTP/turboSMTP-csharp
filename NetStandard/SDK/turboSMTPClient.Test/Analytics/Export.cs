using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using TurboSMTPSDK.Model.Analytics;

namespace TurboSMTPSDK.Test.Analytics
{
    public class Export
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task Export_Analytics_With_Default_Params()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            //Act
            try
            {
                var result = await TS.analytics.Export(
                    DateTime.Now.AddYears(-3),
                    DateTime.Now);
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
        public async Task Export_Analytics_Filtered_By_Subject()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            var keyWord = "test";
            //Act
            var result = await TS.analytics.Export(
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
            Assert.That(result.Length > 0);
            Assert.That(result.Contains(keyWord));
            Assert.Pass();
        }
    }
}

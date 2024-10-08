using NUnit.Framework;
using System;
using System.Threading.Tasks;
using turboSMTP.Test;
using TurboSMTP.Model.Suppressions;

namespace TurboSMTP.Test.Suppressions
{
    public class Export: TestBase
    {
        [Test]
        public async Task Export_Suppressions_With_Default_Params()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

            var exportOptions = new SuppressionsExportOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .Build();

            //Act
            try
            {
                var result = await TS.Suppressions.ExportAsync(exportOptions);
                
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
        public async Task Export_Suppressions_Where_Subject_Contains()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

            var restrictions = new SuppressionsRestriction[]
            {
                new SuppressionsRestriction()
                {
                        By = SuppresionsRestrictionFilterBy.Subject,
                        Filter = "test",
                        SmartSearch = true,
                        Operator = SuppressionsRestrictionOperator.Include
                }
            };

            var exportOptions = new SuppressionsExportOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .SetRestrictions(restrictions)
                .Build();

            //Act
            var result = await TS.Suppressions.ExportAsync(exportOptions);
            //Assert
            Assert.That(result.Length > 0);
            Assert.That(result.Contains(restrictions[0].Filter));
            Assert.Pass();
        }
    }
}

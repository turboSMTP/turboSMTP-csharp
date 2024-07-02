using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboSMTPSDK.Model.Suppressions;

namespace TurboSMTPSDK.Test.Suppressions
{
    public class Export
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task Export_Suppressions_With_Default_Params()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            //Act
            try
            {
                var result = await TS.suppressions.Export(
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
        public async Task Export_Suppressions_Where_Subject_Contains()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            var SubjectContainsKeyword = "test";
            //Act
            var result = await TS.suppressions.Export(
                DateTime.Now.AddYears(-3),
                DateTime.Now,
                new ExportOptions(),
                new List<AdvancedFilter>()
                {
                    new AdvancedFilter()
                    {
                        By = AdvancedFilterBy.Subject,
                        Filter = SubjectContainsKeyword,
                        SmartSearch = true,
                        Operator = AdvancedFilterOperator.Include
                    }
                }
                );
            //Assert
            Assert.That(result.Length > 0);
            Assert.That(result.Contains(SubjectContainsKeyword));
            Assert.Pass();
        }
    }
}

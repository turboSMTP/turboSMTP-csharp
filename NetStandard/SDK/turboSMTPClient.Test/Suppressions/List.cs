using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboSMTPSDK.Model.Suppressions;

namespace TurboSMTPSDK.Test.Suppressions
{
    public class List
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Retrieve_Suppressions_With_Default_Params()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            //Act
            try
            {
                var result = await TS.suppressions.List(
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
        public async Task Retrieve_Suppressions_Whith_Limit()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            var limit = 5;
            //Act
            var result = await TS.suppressions.List(
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
        public async Task Retrieve_Suppressions_Where_Subject_Contains()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            var SubjectContainsKeyword = "team";
            //Act
            var result = await TS.suppressions.List(
                DateTime.Now.AddYears(-3),
                DateTime.Now,
                new ListOptions()
                {
                    limit = 1000
                },
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
            Assert.That(result.Records.All(s => s.Subject.Contains(SubjectContainsKeyword)));
            Assert.Pass();
        }


    }
}

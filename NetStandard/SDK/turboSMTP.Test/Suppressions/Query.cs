using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using turboSMTP.Test;
using TurboSMTP.Model.Suppressions;

namespace TurboSMTP.Test.Suppressions
{
    public class Query: TestBase
    {
        [Test]
        public async Task Query_Suppressions_With_Default_Params()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

            var queryOptions = new SuppressionsQueryOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .Build();

            //Act
            try
            {
                var result = await TS.Suppressions.Query(queryOptions);
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
        public async Task Query_Suppressions_Whith_Limit()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

            var queryOptions = new SuppressionsQueryOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .SetLimit(5)
                .Build();

            //Act
            var result = await TS.Suppressions.Query(queryOptions);
            //Assert
            Assert.That(result.Records.Count <= queryOptions.Limit,$"Limit = {queryOptions.Limit} - Returned results = {result.TotalRecords}");
            Assert.Pass();
        }

        [Test]
        public async Task Query_Suppressions_Where_Subject_Contains()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

            var restrictions = new SuppressionsRestriction[]
                {
                    new SuppressionsRestriction()
                    {
                        By = SuppresionsRestrictionFilterBy.Subject,
                        Filter = "team",
                        SmartSearch = true,
                        Operator = SuppressionsRestrictionOperator.Include
                    }
                };

            var queryOptions = new SuppressionsQueryOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .SetLimit(1000)
                .SetRestrictions(restrictions)
                .Build();

            //Act
            var result = await TS.Suppressions.Query(queryOptions);
            //Assert
            Assert.That(result.Records.All(s => s.Subject.Contains(restrictions[0].Filter)));
            Assert.Pass();
        }


    }
}

using NUnit.Framework;
using System;
using System.Threading.Tasks;
using turboSMTP.Test;
using TurboSMTP;
using TurboSMTP.Model.EmailValidator;

namespace TurboSMTP.Test.EmailValidator
{
    public class List: TestBase
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Retrieve_EmailValidatorLists_With_Default_Params()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);


            var emailValidatorFilesQueryOptions = new EmailValidatorFilesQueryOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .Build();

            //Act
            try
            {
                var result = await TS.EmailValidatorFiles.Query(emailValidatorFilesQueryOptions);
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
        public async Task Retrieve_EmailValidatorLists_Whith_Limit()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

            var emailValidatorFilesQueryOptions = new EmailValidatorFilesQueryOptions.Builder()
                .SetFrom(DateTime.Now.AddYears(-3))
                .SetTo(DateTime.Now)
                .SetLimit(5)
                .Build();

            //Act
            var result = await TS.EmailValidatorFiles.Query(emailValidatorFilesQueryOptions);
            //Assert
            Assert.That(result.Records.Count <= emailValidatorFilesQueryOptions.Limit, $"Limit = {emailValidatorFilesQueryOptions.Limit} - Returned results = {result.TotalRecords}");
            Assert.Pass();
        }
    }
}

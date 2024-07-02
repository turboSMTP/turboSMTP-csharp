using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TurboSMTPSDK.Model.EmailValidator;

namespace TurboSMTPSDK.Test.EmailValidator
{
    public class List
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Retrieve_EmailValidatorLists_With_Default_Params()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            //Act
            try
            {
                var result = await TS.emailValidator.List(
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
        public async Task Retrieve_EmailValidatorLists_Whith_Limit()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            var limit = 5;
            //Act
            var result = await TS.emailValidator.List(
                DateTime.Now.AddYears(-3),
                DateTime.Now,
                new ListOptions()
                {
                    limit = limit
                });
            //Assert
            Assert.That(result.Records.Count <= limit, $"Limit = {limit} - Returned results = {result.TotalRecords}");
            Assert.Pass();
        }
    }
}

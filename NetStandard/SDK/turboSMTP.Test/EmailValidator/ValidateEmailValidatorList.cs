using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turboSMTP.Test;
using TurboSMTP;

namespace TurboSMTP.Test.EmailValidator
{
    public class ValidateEmailValidatorList: TestBase
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Validate_EmailValidator_List_By_ID_Invalid()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            //Act
            try
            {
                var result = await TS.EmailValidatorFiles.Validate(5);
                //Assert
                Assert.That(!result);
            }
            catch (SuccessException) { }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Validate_EmailValidator_List_By_ID_Valid()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            //Act
            try
            {
                var listId = await TS.EmailValidatorFiles.Add($"{DateTime.Now.ToString("ddMMyyyyHHmmss")}emailvalidatorlistValidateTest.txt", new List<string>
                {
                    "sergio.b.c@gmail.com",
                    "sergio.c.c@gmail.com"
                });
                Assert.That(listId > 0);
                var result = await TS.EmailValidatorFiles.Validate(listId);
                //Assert
                Assert.That(result);
            }
            catch (SuccessException) { }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}

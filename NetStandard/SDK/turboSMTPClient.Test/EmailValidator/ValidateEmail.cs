using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboSMTPSDK.Test.EmailValidator
{
    public class ValidateEmail
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Validate_ValidEmail()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            //Act
            try
            {
                var result = await TS.emailValidator.Validate("support@gmail.com");
                //Assert
                Assert.That(result);
            }
            catch (SuccessException) { }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Validate_InlidEmail()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            //Act
            try
            {
                var result = await TS.emailValidator.Validate("support@gggmail.cm");
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

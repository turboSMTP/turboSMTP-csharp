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
    public class Subscription: TestBase
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Retrieve_EmailValidator_Subscription()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            //Act
            try
            {
                var result = await TS.emailValidator.GetEmailValidatorSubscription();
                //Assert
                Assert.That(result != null);
                Assert.Pass(result.ToString());
            }
            catch (SuccessException) { }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            
        }
    }
}

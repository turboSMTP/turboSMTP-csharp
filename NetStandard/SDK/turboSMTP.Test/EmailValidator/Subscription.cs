using NUnit.Framework;
using System;
using System.Threading.Tasks;
using turboSMTP.Test;

namespace TurboSMTP.Test.EmailValidator
{
    public class Subscription: TestBase
    {
        [Test]
        public async Task Get_Subscription()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            
            //Act
            try
            {
                var result = await TS.EmailValidator.GetEmailValidatorSubscription();
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

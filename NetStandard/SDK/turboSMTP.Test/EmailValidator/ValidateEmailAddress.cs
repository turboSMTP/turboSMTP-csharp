using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using turboSMTP.Test;
using static TurboSMTP.Model.EmailValidator.EmailAddressValidationDetails;

namespace TurboSMTP.Test.EmailValidator
{
    public class ValidateEmailAddress: TestBase
    {
        [Test]
        public async Task Validate_Valid_EmailAddress()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            
            //Act
            try
            {
                var result = await TS.EmailValidator.ValidateAsync(AppConstants.ValidEmailAddresses.First());
                //Assert
                Assert.That(result.Email.ToLower()== AppConstants.ValidEmailAddresses.First().ToLower());
                Assert.That(result.Status==EmailAddressValidationStatus.Valid);
            }
            catch (SuccessException) { }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Validate_Invalid_EmailAddress()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            //Act
            try
            {
                var result = await TS.EmailValidator.ValidateAsync(AppConstants.InvalidEmailAddresses.First());
                //Assert
                Assert.That(result.Email.ToLower() == AppConstants.InvalidEmailAddresses.First().ToLower());
                Assert.That(result.Status != EmailAddressValidationStatus.Valid);
            }
            catch (SuccessException) { }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}

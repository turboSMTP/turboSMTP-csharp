using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TurboSMTP;

namespace turboSMTP.Test.EmailValidator.EmailValidatorFiles
{
    public class Get : TestBase
    {
        [Test]
        public async Task Get_By_ID_Invalid()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            
            //Act
            try
            {
                var result = await TS.EmailValidatorFiles.GetAsync(0);
                
                //Assert
                Assert.That(result == null);
            }
            catch (SuccessException) { }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Get_By_ID_Valid()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            
            //Act
            try
            {
                var fileId = await TS.EmailValidatorFiles.AddAsync(
                    $"{GetFormatedDateTimeCompressed()}-EmailvalidatorFile.txt",
                    AppConstants.ValidEmailAddresses.GetRange(0, 2));

                Assert.That(fileId > 0);
                var result = await TS.EmailValidatorFiles.GetAsync(fileId);
                //Assert
                Assert.That(result != null);
                Assert.That(result.TotalEmails, Is.EqualTo(2));
            }
            catch (SuccessException) { }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}

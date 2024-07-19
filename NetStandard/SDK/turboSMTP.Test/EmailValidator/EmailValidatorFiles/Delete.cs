using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TurboSMTP;

namespace turboSMTP.Test.EmailValidator.EmailValidatorFiles
{
    public class Delete : TestBase
    {
        [Test]
        public async Task Delete_By_ID_Invalid()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

            //Act
            try
            {
                var result = await TS.EmailValidatorFiles.Delete(0);
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
        public async Task Delete_By_ID_Valid()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            int fileId = 0;
            //Act
            try
            {
                fileId = await TS.EmailValidatorFiles.Add(
                     $"{GetFormatedDateTimeCompressed()}-EmailvalidatorFile.txt",
                     AppConstants.InvalidEmailAddresses.GetRange(0, 2));

                Assert.That(fileId > 0);
                var result = await TS.EmailValidatorFiles.Delete(fileId);
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

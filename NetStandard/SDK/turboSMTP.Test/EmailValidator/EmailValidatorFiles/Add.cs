using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TurboSMTP;

namespace turboSMTP.Test.EmailValidator.EmailValidatorFiles
{
    public class Add : TestBase
    {
        [Test]
        public async Task Add_With_2_Invalid_Addresses()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

            int fileId = 0;
            
            //Act
            try
            {
                fileId = await TS.EmailValidatorFiles.Add(
                    $"{GetFormatedDateTimeCompressed()}-EmailvalidatorFile.txt",
                    AppConstants.InvalidEmailAddresses.GetRange(0,2));
                
                Assert.That(fileId > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass($"List Id: {fileId}");
        }

        [Test]
        public async Task Add_With_0_Addresses()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            int fileId = 0;
            //Act
            try
            {
                await TS.EmailValidatorFiles.Add($"{GetFormatedDateTimeCompressed()}-EmailvalidatorFile.txt",
                    new List<string>());
            }
            catch (ArgumentException ex)
            {
                Assert.Pass(ex.Message );
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboSMTP;
using TurboSMTP.Model.EmailValidator;

namespace turboSMTP.Test.EmailValidator.EmailValidatorFilesResults
{
    public class Export : TestBase
    {
        [Test]
        public async Task Export_By_File_ID()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            
            //Act
            try
            {
                var fileId = await TS.EmailValidatorFiles.Add(
                    $"{GetFormatedDateTimeCompressed()}-EmailvalidatorFile.txt",
                    AppConstants.ValidEmailAddresses.GetRange(0, 2));

                var options = new EmailValidatorFileResultsQueryOptions.Builder()
                    .SetFileId(fileId)
                    .Build();

                //Assert
                Assert.That(fileId > 0, "Generated Test File Id should be greater than zero");
                var result = await TS.EmailValidatorFileResults.Query(options);
                
                //Assert
                Assert.That(result != null, "File Details results should not be null");
                Assert.That(result.Records.Count == 0, "File Details should not have processed emails until validated");
                
                await TS.EmailValidatorFiles.Validate(fileId);
                var stringResult = await TS.EmailValidatorFileResults.Export(fileId);
                Assert.That(!string.IsNullOrEmpty(stringResult), "File Details result should not be null after validation");
                Assert.That(stringResult.Contains(AppConstants.ValidEmailAddresses.First()), "After validating a File it should contain the address added to validate");
            }
            catch (SuccessException) { }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}

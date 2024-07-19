using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TurboSMTP;
using TurboSMTP.Model.EmailValidator;

namespace turboSMTP.Test.EmailValidator.EmailValidatorFilesResults
{
    public class Get : TestBase
    {
        [Test]
        public async Task Query_With_Default_Params()
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

                Assert.That(fileId > 0, "Generated Test File Id should be greater than zero");
                var result = await TS.EmailValidatorFileResults.Query(options);
                
                //Assert
                Assert.That(result != null, "File Result Details should not be null");
                Assert.That(result.Records.Count == 0, "File should not have processed emails until validated");
                await TS.EmailValidatorFiles.Validate(fileId);
                
                result = await TS.EmailValidatorFileResults.Query(options);
                Assert.That(result != null, "File Result Details should not be null after validation");
                Assert.That(result.Records.Count == 2, "After validating a list it should contain the same ammount of results as items");
            }
            catch (SuccessException) { }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Test]
        public async Task Query_With_Page_Options()
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
                    .SetPage(2)
                    .SetLimit(1)
                    .Build();

                Assert.That(fileId > 0, "Generated Test File should be greater than zero");
                var result = await TS.EmailValidatorFileResults.Query(options);
                
                //Assert
                Assert.That(result != null, "File Result Details should not be null");
                Assert.That(result.Records.Count == 0, "File should not have processed emails until validated");
                
                await TS.EmailValidatorFiles.Validate(fileId);
                result = await TS.EmailValidatorFileResults.Query(options);
                Assert.That(result != null, "File Result Details should not be null after validation");
                Assert.That(result.Records.Count == 1, "After validating a file, a paged list of 1 item per page it should contain 1 item");
                Assert.That(result.Records.Count == 1, "2nd page should contain 1 email");
            }
            catch (SuccessException) { }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
    }
}

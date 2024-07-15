using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using turboSMTP.Test;
using TurboSMTP;
using TurboSMTP.Model.EmailValidator;

namespace TurboSMTP.Test.EmailValidator
{
    public class ExportValidatedFile: TestBase
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Export_By_File_ID()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            //Act
            try
            {
                var listId = await TS.EmailValidatorFiles.Add($"{DateTime.Now.ToString("ddMMyyyyHHmmss")}emailvalidatorlist.txt", new List<string>
                {
                    "sergio.b.c@gmail.com",
                    "sergio.c.c@gmail.com"
                });

                var options = new EmailValidatorFileResultsQueryOptions.Builder()
                    .SetFileId(listId)
                    .Build();

                //Assert
                Assert.That(listId > 0, "Generated Test List should be greater than zero");
                var result = await TS.EmailValidatorFileResults.GetEmailValidationDetailsByList(options);
                //Assert
                Assert.That(result != null, "List Details results should not be null");
                Assert.That(result.Records.Count == 0, "List Details should not have processed emails until validated");
                await TS.EmailValidatorFiles.Validate(listId);
                var stringResult = await TS.EmailValidatorFileResults.Export(listId);
                Assert.That(!String.IsNullOrEmpty(stringResult), "List Details result should not be null after validation");
                Assert.That(stringResult.Contains("sergiobc@gmail.com"), "After validating a list it should contain the address added to validate");
            }
            catch (SuccessException) { }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turboSMTP.Test;
using TurboSMTP;
using TurboSMTP.Model.Shared;

namespace TurboSMTP.Test.EmailValidator
{
    public class GetSingleEmailValidationDetails: TestBase
    {
        [Test]
        public async Task Retrieve_Single_Email_Validation_Details()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            //Act
            try
            {
                var listId = await TS.emailValidator.AddFile($"{DateTime.Now.ToString("ddMMyyyyHHmmss")}emailvalidatorlist.txt", new List<string>
                {
                    "sergio.b.c@gmail.com",
                    "sergio.c.c@gmail.com"
                });
                Assert.That(listId > 0, "Generated Test List should be greater than zero");
                var result = await TS.emailValidator.GetEmailValidationDetailsByList(listId);
                //Assert
                Assert.That(result != null, "List Details results should not be null");
                Assert.That(result.Records.Count == 0, "List Details should not have processed emails until validated");
                await TS.emailValidator.Validate(listId);
                result = await TS.emailValidator.GetEmailValidationDetailsByList(listId, new PageListOptions
                {
                    page = 1,
                    limit = 10
                });
                Assert.That(result != null, "List Details result should not be null after validation");
                Assert.That(result.Records.Count > 0);
                var emailId = result.Records.First().Id;
                var emailDetails = await TS.emailValidator.GetEmailValidationDetailsByEmailId(listId, emailId);
                Assert.That(result.Records.First().Email == emailDetails.Email);
            }
            catch (SuccessException) { }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
    }
}

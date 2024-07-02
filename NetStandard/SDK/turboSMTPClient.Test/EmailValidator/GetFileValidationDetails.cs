using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboSMTPSDK.Model.Shared;

namespace TurboSMTPSDK.Test.EmailValidator
{
    public class GetFileValidationDetails
    {
        [Test]
        public async Task Retrieve_Validation_Details_With_Default_Params()
        {
            //Arrange
            var TS = new TurboSMTPClient();
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
                result = await TS.emailValidator.GetEmailValidationDetailsByList(listId);
                Assert.That(result != null, "List Details result should not be null after validation");
                Assert.That(result.Records.Count == 2, "After validating a list it should contain the same ammount of results as items");
            }
            catch (SuccessException) { }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Test]
        public async Task Retrieve_Validation_Details_With_Page_Options()
        {
            //Arrange
            var TS = new TurboSMTPClient();
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
                result = await TS.emailValidator.GetEmailValidationDetailsByList(listId,new PageListOptions { 
                    page = 2,
                    limit = 1
                });
                Assert.That(result != null, "List Details result should not be null after validation");
                Assert.That(result.Records.Count == 1, "After validating a paged list of 1 item per page it should contain 1 item");
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

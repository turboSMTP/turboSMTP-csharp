using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turboSMTP.Test;
using TurboSMTP;

namespace TurboSMTP.Test.EmailValidator
{
    public class GetFilesList: TestBase
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Get_FilesList_By_ID_Invalid()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            //Act
            try
            {
                var result = await TS.emailValidator.Get(5);
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
        public async Task Get_Files_List_By_ID_Valid()
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
                Assert.That(listId > 0);
                var result = await TS.emailValidator.Get(listId);
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

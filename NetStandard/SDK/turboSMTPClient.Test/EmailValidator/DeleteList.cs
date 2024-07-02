using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboSMTPSDK.Test.Suppressions;

namespace TurboSMTPSDK.Test.EmailValidator
{
    public class DeleteList
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Delete_List_By_ID_Invalid()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            //Act
            try
            {
                var result = await TS.emailValidator.Delete(5);
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
        public async Task Delete_List_By_ID_Valid()
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
                Assert.That(listId > 0);
                var result = await TS.emailValidator.Delete(listId);
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

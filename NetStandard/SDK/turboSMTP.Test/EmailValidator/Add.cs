using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turboSMTP.Test;
using TurboSMTP;
using TurboSMTP.Test.Suppressions;

namespace TurboSMTP.Test.EmailValidator
{
    public class Add: TestBase
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Add_List_With_2_Invalid_Addresses()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            int listId = 0;
            //Act
            try
            {
                listId = await TS.EmailValidatorFiles.Add($"{DateTime.Now.ToString("ddMMyyyyHHmmss")}emailvalidatorlist.txt", new List<string>
                {
                    "sergio.b.c@gmail.com",
                    "sergio.c.c@gmail.com"
                });
                Assert.That(listId > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass($"List Id: {listId}");
        }

        [Test]
        public async Task Add_List_With_0_Addresses()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            int listId = 0;
            //Act
            try
            {
                listId = await TS.EmailValidatorFiles.Add($"{DateTime.Now.ToString("ddMMyyyyHHmmss")}emailvalidatorlist.txt", new List<string>
                {
                });
                Assert.That(listId > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass($"List Id: {listId}");
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turboSMTP.Test;
using TurboSMTP;

namespace TurboSMTP.Test.Suppressions
{
    public class Add: TestBase
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task Add_3_Valid_2_Invalid()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            var AddressToAdd1 = $"{DateTime.Now.ToString("ddMMyyyyHHmmss")}test1.multiple@gmail.com";
            var AddressToAdd2 = $"{DateTime.Now.ToString("ddMMyyyyHHmmss")}test2.multiple@gmail.com";
            var AddressToAdd3 = $"{DateTime.Now.ToString("ddMMyyyyHHmmss")}test3.multiple@gmail.com";
            //Act
            try
            {
                var result = await TS.Suppressions.AddRange(
                    $"Adding Multiple - {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}",
                    new List<string>()
                    {
                        AddressToAdd1,
                        AddressToAdd2,
                        AddressToAdd3,
                        "testinginvalid",
                        "testinginvalid@gmail@hotmail@google.com"
                    }
                    );
                //Assert
                Assert.That(result.Valid.Count == 3);
                Assert.That(result.Invalid.Count == 2);
                Assert.That(result.Valid.Contains(AddressToAdd1));
                Assert.That(result.Valid.Contains(AddressToAdd2));
                Assert.That(result.Valid.Contains(AddressToAdd3));
                Assert.That(result.Invalid.Contains("testinginvalid"));
                Assert.That(result.Invalid.Contains("testinginvalid@gmail@hotmail@google.com"));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }

        [Test]
        public async Task Add_1_Valid()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            var AddressToAdd = $"{DateTime.Now.ToString("ddMMyyyyHHmmss")}valid1.single@gmail.com";
            //Act
            try
            {
                var result = await TS.Suppressions.Add(
                    $"Adding Single - {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}",
                    AddressToAdd
                    );
                //Assert
                Assert.That(result.Valid.Count == 1);
                Assert.That(result.Invalid.Count == 0);
                Assert.That(result.Valid.Contains(AddressToAdd));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }

        [Test]
        public async Task Add_1_Invalid()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            //Act
            try
            {
                var result = await TS.Suppressions.Add(
                    $"Adding Invalid - {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}",
                    "valid1@gmail"
                    );
                //Assert
                Assert.That(result.Valid.Count == 0);
                Assert.That(result.Invalid.Count == 1);
                Assert.That(result.Invalid.Contains("valid1@gmail"));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }


    }
}

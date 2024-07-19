using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using turboSMTP.Test;

namespace TurboSMTP.Test.Suppressions
{
    public class Add: TestBase
    {
        [Test]
        public async Task Add_3_Valid_2_Malformed()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

            var emailAddressesToAdd = new List<string>()
            {
                $"{GetFormatedDateTimeCompressed()}test1.multiple@gmail.com",
                $"{GetFormatedDateTimeCompressed()}test2.multiple@gmail.com",
                $"{GetFormatedDateTimeCompressed()}test3.multiple@gmail.com",
                "testinginvalid",
                "testinginvalid@gmail@hotmail@google.com"
            };
            
            //Act
            try
            {
                var result = await TS.Suppressions.AddRange("Adding Multiple - {GetFormatedDateTime()}",emailAddressesToAdd);
                //Assert
                Assert.That(result.Valid.Count == 3);
                Assert.That(result.Invalid.Count == 2);
                Assert.That(result.Valid.Contains(emailAddressesToAdd[0]));
                Assert.That(result.Valid.Contains(emailAddressesToAdd[1]));
                Assert.That(result.Valid.Contains(emailAddressesToAdd[2]));
                Assert.That(result.Invalid.Contains(emailAddressesToAdd[3]));
                Assert.That(result.Invalid.Contains(emailAddressesToAdd[4]));
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
            var emailAddressToAdd = $"{GetFormatedDateTimeCompressed()}valid1.single@gmail.com";
            //Act
            try
            {
                var result = await TS.Suppressions.Add($"Adding Single - {GetFormatedDateTime()}", emailAddressToAdd);
                
                //Assert
                Assert.That(result.Valid.Count == 1);
                Assert.That(result.Invalid.Count == 0);
                Assert.That(result.Valid.Contains(emailAddressToAdd));
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

            var emailAddressToAdd = $"{GetFormatedDateTimeCompressed()}invalidvalid.single@gmail";

            //Act
            try
            {
                var result = await TS.Suppressions.Add($"Adding Invalid - {GetFormatedDateTime()}", emailAddressToAdd);
                
                //Assert
                Assert.That(result.Valid.Count == 0);
                Assert.That(result.Invalid.Count == 1);
                Assert.That(result.Invalid.Contains(emailAddressToAdd));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }


    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TurboSMTPSDK.Model.Suppressions;

namespace TurboSMTPSDK.Test.Suppressions
{
    public class Delete
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Delete_Empty_Email()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            //Act
            try
            {
                var result = await TS.suppressions.Delete(null);
                //Assert
                Assert.That(!result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }

        [Test]
        public async Task Delete_Empty_Range()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            //Act
            try
            {
                var result = await TS.suppressions.DeleteRange(new List<string>());
                //Assert
                Assert.That(!result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }

        [Test]
        public async Task Delete_1_InvalidAddress()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            var emailToDelete = "randomabcd";
            //Act
            try
            {
                var result = await TS.suppressions.Delete(emailToDelete);
                //Assert
                Assert.That(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }


        [Test]
        public async Task Delete_1AddedAddress()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            var emailToDelete = "abcd@gmail.com";
            //Act
            try
            {
                var addResult = await TS.suppressions.Add($"Adding One to Delete - {DateTime.Now.ToString("dd/MM/yy HH:mm:ss")}", emailToDelete);
                var result = await TS.suppressions.Delete(emailToDelete);
                //Assert
                Assert.That(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }

        [Test]
        public async Task Delete_2AddedAddress()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            var emailsToDelete = new List<string>() { "abcd@gmail.com", "efgh@gmail.com" };
            //Act
            try
            {
                var addResult = await TS.suppressions.AddRange($"Adding Multiple to Delete - {DateTime.Now.ToString("dd/MM/yy HH:mm:ss")}", emailsToDelete);
                var result = await TS.suppressions.DeleteRange(emailsToDelete);
                //Assert
                Assert.That(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }
        
        [Test]
        public async Task Delete_Today_Suppressions_With_Default_Params()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            //Act
            try
            {
                var addResult = await TS.suppressions.Add($"Adding To Delete Today Test - {DateTime.Now.ToString("dd/MM/yy HH:mm:ss")}",
                    $"{DateTime.Now.ToString("ddMMyyyyHHmmss")}random@gmail.com"
                    );
                var result = await TS.suppressions.Delete(
                    DateTime.Now,
                    DateTime.Now);
                Assert.That(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }

        [Test]
        public async Task Delete_Manual_Suppressions()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            var addResult = await TS.suppressions.Add($"Adding To Delete Manual Test - {DateTime.Now.ToString("dd/MM/yy HH:mm:ss")}",
                $"{DateTime.Now.ToString("ddMMyyyyHHmmss")}random@gmail.com"
                );
            //Act
            var result = await TS.suppressions.Delete(
                DateTime.Now,
                DateTime.Now,
                new DeleteOptions()
                {
                    filter = "",
                    filterBy = new List<Source>() { Source.Manual}
                }
                );
            //Assert
            Assert.That(result);
            Assert.Pass();
        }

        [Test]
        public async Task Delete_Suppressions_WithFilter()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            var addResult = await TS.suppressions.Add($"Adding To Delete Manual Test - {DateTime.Now.ToString("dd/MM/yy HH:mm:ss")}",
                $"{DateTime.Now.ToString("ddMMyyyyHHmmss")}random@gmail.com"
                );
            //Act
            var result = await TS.suppressions.Delete(
                DateTime.Now,
                DateTime.Now,
                new DeleteOptions()
                {
                    filter = "Delete Manual",
                    smartSearch = true
                }
                );
            //Assert
            Assert.That(result);
            Assert.Pass();
        }

        [Test]
        public async Task Delete_Suppressions_Where_Reason_Contains()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            var ReasonContainsKeyword = "Subject Contains";
            var addResult = await TS.suppressions.Add($"Adding To Delete By Subject Contains - {DateTime.Now.ToString("dd/MM/yy HH:mm:ss")}",
                $"{DateTime.Now.ToString("ddMMyyyyHHmmss")}random@gmail.com"
                );
            //Act
            var result = await TS.suppressions.Delete(
                DateTime.Now,
                DateTime.Now,
                null,
                new List<AdvancedFilter>()
                {
                    new AdvancedFilter()
                    {
                        By = AdvancedFilterBy.Reason,
                        Filter = ReasonContainsKeyword,
                        SmartSearch = true,
                        Operator = AdvancedFilterOperator.Include
                    }
                }
                );
            //Assert
            Assert.That(result);
            Assert.Pass();
        }


    }
}

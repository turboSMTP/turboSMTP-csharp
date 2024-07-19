using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using turboSMTP.Test;
using TurboSMTP.Domain;
using TurboSMTP.Model.Suppressions;

namespace TurboSMTP.Test.Suppressions
{
    public class Delete: TestBase
    {
        [Test]
        public async Task Delete_Empty_Range()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            
            //Act
            try
            {
                var result = await TS.Suppressions.DeleteRange(new List<string>());
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
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            
            var emailAddressToDelete = "randomabcd";
            
            //Act
            try
            {
                var result = await TS.Suppressions.Delete(emailAddressToDelete);
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
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            
            var emailAddressToDelete = "abcd@gmail.com";
            //Act
            try
            {
                await TS.Suppressions.Add($"Adding One to Delete - {GetFormatedDateTime()}", emailAddressToDelete);
                
                var result = await TS.Suppressions.Delete(emailAddressToDelete);
                
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
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);
            
            var emailAddressesToDelete = new List<string>() { "abcd@gmail.com", "efgh@gmail.com" };
            
            //Act
            try
            {
                await TS.Suppressions.AddRange($"Adding Multiple to Delete - {GetFormatedDateTime()}", emailAddressesToDelete);
                
                var result = await TS.Suppressions.DeleteRange(emailAddressesToDelete);
                
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
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

            var deleteOptions = new SuppressionsDeleteOptions.Builder()
                .SetFrom(DateTime.Now)
                .SetTo(DateTime.Now)
                .Build();

            //Act
            try
            {
                await TS.Suppressions.Add($"Adding To Delete Today Test - {GetFormatedDateTime()}",
                    $"{GetFormatedDateTimeCompressed()}random@gmail.com"
                    );
                
                var result = await TS.Suppressions.Delete(deleteOptions);
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
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

            var deleteOptions = new SuppressionsDeleteOptions.Builder()
                .SetFrom(DateTime.Now)
                .SetTo(DateTime.Now)
                .SetFilter("")
                .SetFilterBy(new SuppresionSource[] { SuppresionSource.Manual })
                .Build();
                

            await TS.Suppressions.Add($"Adding To Delete Manual Test - {GetFormatedDateTime()}",
                $"{GetFormatedDateTimeCompressed()}random@gmail.com"
                );
            
            //Act
            var result = await TS.Suppressions.Delete(deleteOptions);
            
            //Assert
            Assert.That(result);
            Assert.Pass();
        }

        [Test]
        public async Task Delete_Suppressions_WithFilter()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

            var deleteOptions = new SuppressionsDeleteOptions.Builder()
                .SetFrom(DateTime.Now)
                .SetTo(DateTime.Now)
                .SetFilter("Delete Manual")
                .SetSmartSearch(true)
                .Build();

            var addResult = await TS.Suppressions.Add($"Adding To Delete Manual Test - {GetFormatedDateTime()}",
                $"{GetFormatedDateTimeCompressed()}random@gmail.com"
                );
            //Act
            
            var result = await TS.Suppressions.Delete(deleteOptions);
            //Assert
            Assert.That(result);
            Assert.Pass();
        }

        [Test]
        public async Task Delete_Suppressions_Where_Reason_Contains()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

            var restriction = new SuppressionsRestriction[]
                {
                    new SuppressionsRestriction()
                    {
                        By = SuppresionsRestrictionFilterBy.Reason,
                        Filter = "Subject Contains",
                        SmartSearch = true,
                        Operator = SuppressionsRestrictionOperator.Include
                    }
                };

            var deleteOptions = new SuppressionsDeleteOptions.Builder()
                .SetFrom(DateTime.Now)
                .SetTo(DateTime.Now)
                .SetRestrictions(restriction)
                .Build();
            
            var addResult = await TS.Suppressions.Add($"Adding To Delete By Subject Contains - {GetFormatedDateTime()}",
                $"{GetFormatedDateTimeCompressed()}random@gmail.com"
                );
            
            //Act
            var result = await TS.Suppressions.Delete(deleteOptions);
            //Assert
            Assert.That(result);
            Assert.Pass();
        }


    }
}

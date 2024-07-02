﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboSMTPSDK.Test.EmailValidator
{
    public class Subscription
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Retrieve_EmailValidator_Subscription()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            //Act
            try
            {
                var result = await TS.emailValidator.Subscription();
                //Assert
                Assert.That(result != null);
                Assert.Pass(result.ToString());
            }
            catch (SuccessException) { }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            
        }
    }
}

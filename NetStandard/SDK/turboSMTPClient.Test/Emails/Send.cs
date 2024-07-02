using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TurboSMTPSDK.Model.Email;
using Email = TurboSMTPSDK.Model.Email.Email;

namespace TurboSMTPSDK.Test.Emails
{
    public class Send
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Send_Simple_Email()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            var email = new Email()
            {
                From = "msaad@emailchef.com",
                To = new List<string>() { "sergio.a.matteoda@gmail.com" },
                Subject= "Une seule pièce ensemble from c#",
                Content = "This is the first in a row"
            };
            //Act
            try
            {
                var result = await TS.emails.Send(email);
                //Assert
                Assert.That(result.Message == "OK");
                Assert.That(result.Mid > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }

        [Test]
        public async Task Send_Complete_Email_Attachment_As_Base64()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            var email = new Email()
            {
                From = "msaad@emailchef.com",
                To = new List<string>() { "sergio.a.matteoda@gmail.com" },
                Subject = $"Full-Email {DateTime.Now.ToString("dd/MM/YYYY HH:mm:ss")}",
                Content = "This is the first in a row",
                HtmlContent = "This is <b>html</b> content<br/><br/>",
                CustomHeaders = new Dictionary<string, string>
                {
                    { "List-Unsubscribe", "<https://www.example.com/unlist?id=8822772727>" },
                    { "X-Entity-Ref-ID", "4ec7b020-51dc-442f-bd39-9b0a32c3eb83" },
                    { "Tracking-Id", "888884433" },
                    { "reply-to", "alternative-email@domain.com" }
                },
                ReferenceId = $"SystemRef{new Random().Next()}",
                Attachments = new List<Attachment>()
                {
                    new Attachment(
                        Convert.ToBase64String(Encoding.UTF8.GetBytes("This is a sample text within a file")),
                        "SampleDocument.txt",
                        "text/plain"
                    )
                }
            };
            //Act
            try
            {
                var result = await TS.emails.Send(email);
                //Assert
                Assert.That(result.Message == "OK");
                Assert.That(result.Mid > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }

        [Test]
        public async Task Send_Complete_Email_AttachFromFile()
        {
            //Arrange
            var TS = new TurboSMTPClient();
            var email = new Email()
            {
                From = "msaad@emailchef.com",
                To = new List<string>() { "sergio.a.matteoda@gmail.com" },
                Subject = $"Full-Email-Files-Attached {DateTime.Now.ToString("dd/MM/YYYY HH:mm:ss")}",
                Content = "This is the first in a row",
                HtmlContent = "This is <b>html</b> content<br/><br/>",
                CustomHeaders = new Dictionary<string, string>
                {
                    { "List-Unsubscribe", "<https://www.example.com/unlist?id=8822772727>" },
                    { "X-Entity-Ref-ID", "4ec7b020-51dc-442f-bd39-9b0a32c3eb83" },
                    { "Tracking-Id", "888884433" },
                    { "reply-to", "alternative-email@domain.com" }
                },
                ReferenceId = $"SystemRef{new Random().Next()}",
                Attachments = new List<Attachment>()
                {
                    new Attachment(
                        Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        "Emails/SampleFiles/sample.png")
                    ),
                    new Attachment(
                        Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        "Emails/SampleFiles/dummy.pdf"),"renamed.pdf"
                    )
                }
            };
            //Act
            try
            {
                var result = await TS.emails.Send(email);
                //Assert
                Assert.That(result.Message == "OK");
                Assert.That(result.Mid > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }
    }
}

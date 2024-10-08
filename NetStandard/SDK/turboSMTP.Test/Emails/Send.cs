using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using turboSMTP.Test;
using TurboSMTP.Domain;

namespace TurboSMTP.Test.Emails
{
    public class Send: TestBase
    {
        [Test]
        public async Task Send_Simple_Email()
        {
            //Arrange
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

            var emailMessage = new EmailMessage.Builder()
                .SetFrom(AppConstants.EmailSender)
                .AddTo(AppConstants.ValidEmailAddresses.First())
                .SetSubject("Trivia contest simple email")
                .SetHtmlContent("Do not loose the opportunity to participate.")
                .Build();

            //Act
            try
            {
                var result = await TS.Emails.SendAsync(emailMessage);
                //Assert
                Assert.That(result.Message == "OK");
                Assert.That(result.MessageID > 0);
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
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

            var emailAttachment = new EmailAttachment(
                        Convert.ToBase64String(Encoding.UTF8.GetBytes("This is a sample text within a file")),
                        "SampleDocument.txt",
                        "text/plain");

            var emailMessage = new EmailMessage.Builder()
                .SetFrom(AppConstants.EmailSender)
                .AddTo(AppConstants.ValidEmailAddresses[0])
                .AddTo(AppConstants.ValidEmailAddresses[1])
                .SetSubject($"Full-Email - {GetFormatedDateTime()}")
                .SetHtmlContent("This is <b>html</b> content<br/><br/>")
                .AddCustomHeader("List-Unsubscribe", "<https://www.example.com/unlist?id=8822772727>")
                .AddCustomHeader("X-Entity-Ref-ID", "4ec7b020-51dc-442f-bd39-9b0a32c3eb83")
                .AddCustomHeader("Tracking-Id", "888884433")
                .AddCustomHeader("reply-to", "alternative-email@domain.com")
                .SetReferenceId($"SystemRef{new Random().Next()}")
                .SetCampaignID("TestSDK")
                .AddAttachment(emailAttachment)
                .Build();

            //Act
            try
            {
                var result = await TS.Emails.SendAsync(emailMessage);
                //Assert
                Assert.That(result.Message == "OK");
                Assert.That(result.MessageID > 0);
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
            var TS = new TurboSMTPClient(TurboSMTPClientConfiguration.Instance);

            var emailAttachment_1 = new EmailAttachment(
                        Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        "Emails/SampleFiles/sample.png"));

            var emailAttachment_2 = new EmailAttachment(
                        Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        "Emails/SampleFiles/dummy.pdf"), "renamed.pdf");

            var emailMessage = new EmailMessage.Builder()
                .SetFrom(AppConstants.EmailSender)
                .AddTo(AppConstants.ValidEmailAddresses.First())
                .SetSubject($"Full-Email-Files-Attached - {GetFormatedDateTime()}")
                .SetContent("This is the text version")
                .SetHtmlContent("This is <b>html</b> content<br/><br/>")
                .AddCustomHeader("List-Unsubscribe", "<https://www.example.com/unlist?id=8822772727>")
                .AddCustomHeader("X-Entity-Ref-ID", "4ec7b020-51dc-442f-bd39-9b0a32c3eb83")
                .AddCustomHeader("Tracking-Id", "888884433")
                .AddCustomHeader("reply-to", "alternative-email@domain.com")
                .SetReferenceId($"SystemRef{new Random().Next()}")
                .SetCampaignID("TestSDK")
                .AddAttachment(emailAttachment_1)
                .AddAttachment(emailAttachment_2)
                .Build();

            //Act
            try
            {
                var result = await TS.Emails.SendAsync(emailMessage);
                //Assert
                Assert.That(result.Message == "OK");
                Assert.That(result.MessageID > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }
    }
}

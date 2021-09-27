using NUnit.Framework;
using MailRuPages = Mail.MailServices.MailRu;
using GmailPages = Mail.MailServices.Gmail;
using Mail.Util;
using Mail.Service;

namespace MailWebDriverTests
{
    [TestFixture]
    public class ReplyLetterGoogleMailTests : CommonConditions
    {
        [SetUp]
        public void SendLetterFromMailRu()
        {
            MailRuPages.WriteLetter.WriteLetterPage writeLetter
                = CreateDefaultMailRuPageUtils.CreateWriteLetterPage(_driver, UserCreator.UserMailRu);

            writeLetter.WriteLetter(LetterCreator.SendLetter);
        }

        [Test]
        [Category("All")]
        public void IsCorrectLetter_CoorectLetter_ReturnTrue()
        {
            GmailPages.Inbox.InboxPage inboxPage
                = CreateDefaultGmailPageUtils.CreateInboxPage(_driver, UserCreator.UserGmail);

            bool isNotReaded = inboxPage.IsNotReadedLastIncomingLetter();
            Assert.IsTrue(isNotReaded, "The letter is displayed as read.");

            string actualSender = inboxPage.GetSenderEmail();
            Assert.AreEqual(UserCreator.UserMailRu.Email, actualSender,
                $"Sender \"{actualSender}\" is not equal to expected sender \"{UserCreator.UserMailRu.Email}\".");

            string actualLettersText = inboxPage.GetLetterText();
            Assert.AreEqual(LetterCreator.SendLetter.Text, actualLettersText,
                $"The text of the letter:\"{LetterCreator.SendLetter.Text}\", " +
                $"does not match the expected:\"{actualLettersText}\".");
        }
    }
}

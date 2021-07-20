using OpenQA.Selenium;
using NUnit.Framework;
using MailRuPages = Mail.MailRu;
using GmailPages = Mail.Gmail;

namespace MailWebDriverTests
{
    [TestFixture]
    public class ReplyLetterGoogleMailTests : CommonConditions
    {
        [SetUp]
        public void SendLetterFromMailRu()
        {
            MailRuPages.Login.LoginPage loginPage = CreateDefaultMailRuLoginPage(_driver);
            var page = loginPage.LoginAs(UserMailRu);

            MailRuPages.Home.HomePage homePage = page as MailRuPages.Home.HomePage;

            MailRuPages.WriteLetter.WriteLetterPage writeLetter
                = homePage.OpenWriteLetterPage();

            writeLetter.WriteLetter(SendLetter);
        }

        [Test]
        public void IsCorrectLetter_CoorectLetter_ReturnTrue()
        {
            GmailPages.Login.LoginPage loginPage = CreateDefaultGmailLoginPage(_driver);
            var page = loginPage.LoginAs(UserGmail);

            GmailPages.Home.HomePage homePage = page as GmailPages.Home.HomePage;

            GmailPages.Inbox.InboxPage inboxPage = homePage.OpenInboxPage();

            bool isNotReaded = inboxPage.IsNotReadedLastIncomingLetter();
            Assert.IsTrue(isNotReaded, "The letter is displayed as read.");

            string actualSender = inboxPage.GetSenderEmail();
            Assert.AreEqual(UserMailRu.Email, actualSender,
                $"Sender \"{actualSender}\" is not equal to expected sender \"{UserMailRu.Email}\".");

            string actualLettersText = inboxPage.GetLetterText();
            Assert.AreEqual(SendLetter.Text, actualLettersText,
                $"The text of the letter:\"{SendLetter.Text}\", " +
                $"does not match the expected:\"{actualLettersText}\".");

        }

        /// <summary>
        /// Creates an instance of the LoginPage class.
        /// </summary>
        /// <param name="driver">An instance of the web driver.</param>
        /// <returns>Login page.</returns>
        private MailRuPages.Login.LoginPage CreateDefaultMailRuLoginPage(IWebDriver driver)
        {
            MailRuPages.Login.LoginPage loginPage
                = new MailRuPages.Login.LoginPage(driver);
            loginPage.OpenLoginPage();

            return loginPage;
        }

        /// <summary>
        /// Creates an instance of the LoginPage class.
        /// </summary>
        /// <returns>Login page.</returns>
        private GmailPages.Login.LoginPage CreateDefaultGmailLoginPage(IWebDriver driver)
        {
            GmailPages.Login.LoginPage loginPage
               = new GmailPages.Login.LoginPage(driver);
            loginPage.OpenLoginPage();

            return loginPage;
        }
    }
}
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Mail.Base;
using MailRuPages = Mail.MailRu;
using GmailPages = Mail.Gmail;

namespace MailWebDriverTests
{
    [TestFixture]
    public class ReplyLetterGoogleMailTests
    {
        public User MailRuUser => new User("robert.langdon.84@mail.ru", "158274Up");

        public User GmailUser => new User("g1mail2com3test@gmail.com", "Road1285");

        public Letter SendLetter => new Letter(GmailUser.Email, "Hello World!");

        private IWebDriver _driver;

        [SetUp]
        public void SendLetterFromMailRu()
        {
            _driver = new ChromeDriver();

            MailRuPages.Login.LoginPage loginPage = CreateDefaultMailRuLoginPage(_driver);
            var page = loginPage.LoginAs(MailRuUser);

            MailRuPages.Home.HomePage homePage = page as MailRuPages.Home.HomePage;

            MailRuPages.WriteLetter.WriteLetterPage writeLetter
                = homePage.OpenWriteLetterPage();

            writeLetter.WriteLetter(SendLetter);
        }

        [Test]
        public void IsCorrectLetter_CoorectLetter_ReturnTrue()
        {
            GmailPages.Login.LoginPage loginPage = CreateDefaultGmailLoginPage(_driver);
            var page = loginPage.LoginAs(GmailUser);

            GmailPages.Home.HomePage homePage = page as GmailPages.Home.HomePage;

            GmailPages.Inbox.InboxPage inboxPage = homePage.OpenInboxPage();

            bool isNotReaded = inboxPage.IsNotReadedLastIncomingLetter();
            Assert.IsTrue(isNotReaded, "The letter is displayed as read.");

            string actualSender = inboxPage.GetSenderEmail();
            Assert.AreEqual(MailRuUser.Email, actualSender,
                $"Sender \"{actualSender}\" is not equal to expected sender \"{MailRuUser.Email}\".");

            string actualLettersText = inboxPage.GetLetterText();
            Assert.AreEqual(SendLetter.Text, actualLettersText,
                $"The text of the letter:\"{SendLetter.Text}\", " +
                $"does not match the expected:\"{actualLettersText}\".");

        }

        [TearDown]
        public void DriverQuit()
        {
            _driver.Quit();
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
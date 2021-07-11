using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace MailWebDriverTests
{
    [TestFixture]
    public class ReplyLetterGoogleMailTests
    {
        private readonly string _emailMailRu = "robert.langdon.84@mail.ru";
        private readonly string _passwordMailRu = "158274Up";
        private readonly string _emailGoogle = "g1mail2com3test@gmail.com";
        private readonly string _passwordGoogle = "Road1285";
        private readonly string _lettersText = "Hello World!";
        private readonly string _mailRuLoginPagePath = "https://account.mail.ru/login";
        private readonly string _googleMailLoginPagePath = "https://accounts.google.com/ServiceLogin/identifier?passive=1209600&continue=https%3A%2F%2Faccounts.google.com%2Fb%2F0%2FAddMailService&followup=https%3A%2F%2Faccounts.google.com%2Fb%2F0%2FAddMailService&flowName=GlifWebSignIn&flowEntry=ServiceLogin";
        private IWebDriver _driver;

        [SetUp]
        public void SendLetterFromMailRu()
        {
            OpenPageByUrl(_mailRuLoginPagePath);
            MailRuModel.Pages.LoginPage loginPage = new MailRuModel.Pages.LoginPage(_driver);
            MailRuModel.Pages.HomePage homePage = loginPage.LoginAs(_emailMailRu, _passwordMailRu);
            MailRuModel.Pages.WriteLetterPage writeLetterPage = homePage.OpenWriteLetterPage();
            writeLetterPage.WriteLetter(_emailGoogle, _lettersText);
            _driver.Quit();
        }

        [Test]
        public void IsNotReadedLastIncomingLetter_CorrectLetter_ReturnTrue()
        {
            OpenPageByUrl(_googleMailLoginPagePath);
            GoogleMailModel.Pages.LoginPage loginPage = new GoogleMailModel.Pages.LoginPage(_driver);
            GoogleMailModel.Pages.HomePage homePage = loginPage.LoginAs(_emailGoogle, _passwordGoogle);
            GoogleMailModel.Pages.InboxPage inboxPage = homePage.OpenInboxPage();

            bool condition = inboxPage.IsNotReadedLastIncomingLetter();

            Assert.IsTrue(condition);
        }

        [Test]
        public void IsExpectedSender_CorrectLetter_ReturnTrue()
        {
            OpenPageByUrl(_googleMailLoginPagePath);
            GoogleMailModel.Pages.LoginPage loginPage = new GoogleMailModel.Pages.LoginPage(_driver);
            GoogleMailModel.Pages.HomePage homePage = loginPage.LoginAs(_emailGoogle, _passwordGoogle);
            GoogleMailModel.Pages.InboxPage inboxPage = homePage.OpenInboxPage();

            string actualSender = inboxPage.GetSenderEmail();

            Assert.AreEqual(_emailMailRu, actualSender);
        }

        [Test]
        public void IsExpectedLetterText_CorrectLetter_ReturnTrue()
        {
            OpenPageByUrl(_googleMailLoginPagePath);
            GoogleMailModel.Pages.LoginPage loginPage = new GoogleMailModel.Pages.LoginPage(_driver);
            GoogleMailModel.Pages.HomePage homePage = loginPage.LoginAs(_emailGoogle, _passwordGoogle);
            GoogleMailModel.Pages.InboxPage inboxPage = homePage.OpenInboxPage();
            inboxPage.OpenLastIncomingLetter();

            string actualSender = inboxPage.GetLetterText();

            Assert.AreEqual(_lettersText, actualSender);
        }


        [TearDown]
        public void DriverQuit()
        {
            _driver.Quit();
        }

        /// <summary>
        /// Opens the page with the specified Url.
        /// </summary>
        /// <param name="loginPageUrl">Url of the page to be opened.</param>
        private void OpenPageByUrl(string loginPageUrl)
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(loginPageUrl);
        }
    }
}

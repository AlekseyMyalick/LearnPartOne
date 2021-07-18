using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using MailRu = MailRuModel.Pages;
using Gmail = GoogleMailModel.Pages;

namespace MailWebDriverTests
{
    [TestFixture]
    public class NicknameChangeTests
    {
        private readonly string _emailMailRu = "robert.langdon.84@mail.ru";
        private readonly string _passwordMailRu = "158274Up";
        private readonly string _emailGoogle = "g1mail2com3test@gmail.com";
        private readonly string _passwordGoogle = "Road1285";
        private readonly string _lettersText = "Hello World!";
        private readonly string _oldNickname = "Robert Langdon";
        private readonly string _newNickname = "Robdon";
        private readonly string _lettersResponse = "Hello my dear friend!";
        private readonly string _mailRuLoginPagePath = "https://account.mail.ru/login";
        private readonly string _googleMailLoginPagePath = "https://accounts.google.com/ServiceLogin/identifier?passive=1209600&continue=https%3A%2F%2Faccounts.google.com%2Fb%2F0%2FAddMailService&followup=https%3A%2F%2Faccounts.google.com%2Fb%2F0%2FAddMailService&flowName=GlifWebSignIn&flowEntry=ServiceLogin";

        private IWebDriver _driver;

        [SetUp]
        public void SendLetterFromMailRu()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(_mailRuLoginPagePath);

            MailRu.HomePage homePageMailRu =
                CreateDefaultMailRuHomePage(_driver, _emailMailRu, _passwordMailRu);
            MailRu.WriteLetterPage writeLetterPageMailRu = homePageMailRu.OpenWriteLetterPage();

            writeLetterPageMailRu.WriteLetter(_emailGoogle, _lettersText);
        }

            [Test]
        public void NicknameChange_CorrectChange_ReturnTrue()
        {
            _driver.Navigate().GoToUrl(_googleMailLoginPagePath);

            Gmail.HomePage homePageGmail =
                CreateDefaultGoogleHomePage(_driver, _emailGoogle, _passwordGoogle);
            Gmail.InboxPage inboxPageGmail = homePageGmail.OpenInboxPage();
            inboxPageGmail.ReplyToLastLetter(_lettersResponse, _newNickname);

            _driver.Navigate().GoToUrl(_mailRuLoginPagePath);

            MailRu.HomePage homePageMailRu =
                CreateDefaultMailRuHomePage(_driver, _emailMailRu, _passwordMailRu);
            MailRu.PersonalDataPage personalDataPageMailRu =
                homePageMailRu.OpenPersonalDataPage();
            personalDataPageMailRu.ChangeNickname(_newNickname);
            homePageMailRu = personalDataPageMailRu.OpenHomePage();
            personalDataPageMailRu = homePageMailRu.OpenPersonalDataPage();

            string actualNickname = personalDataPageMailRu.GetNickname();

            Assert.AreEqual(_newNickname, actualNickname,
                $"The alias \"{actualNickname}\" does not " +
                $"match the expected \"{_newNickname}\".");
        }

        [TearDown]
        public void ReplaceWithOldAlias()
        {
            _driver.Navigate().GoToUrl(_mailRuLoginPagePath);

            MailRu.HomePage homePageMailRu =
                CreateDefaultMailRuHomePage(_driver, _emailMailRu, _passwordMailRu);
            MailRu.PersonalDataPage personalDataPageMailRu =
                homePageMailRu.OpenPersonalDataPage();
            personalDataPageMailRu.ChangeNickname(_oldNickname);

            _driver.Quit();
        }

        /// <summary>
        /// Opens a home page in the MailRu server.
        /// </summary>
        /// <param name="driver">An instance of the web driver.</param>
        /// <param name="email">Login to enter.</param>
        /// <param name="password">Login password.</param>
        /// <returns>Home page.</returns>
        private MailRu.HomePage CreateDefaultMailRuHomePage
            (IWebDriver driver, string email, string password)
        {
            MailRu.LoginPage loginPage = new MailRu.LoginPage(driver);

            return loginPage.LoginAs(email, password);
        }

        /// <summary>
        /// Opens a home page in the Google service.
        /// </summary>
        /// <param name="driver">An instance of the web driver.</param>
        /// <param name="email">Login to enter.</param>
        /// <param name="password">Login password.</param>
        /// <returns>Home page.</returns>
        private Gmail.HomePage CreateDefaultGoogleHomePage
            (IWebDriver driver, string email, string password)
        {
            Gmail.LoginPage loginPage = new Gmail.LoginPage(driver);

            return loginPage.LoginAs(email, password);
        }
    }
}

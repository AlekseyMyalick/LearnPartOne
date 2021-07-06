using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using MailRuModel.Pages;

namespace MailWebDriverTests
{
    [TestFixture]
    public class LoginMailRuTests
    {
        private readonly string _driverPath = @"D:\ChromDriver";
        private readonly string _loginPagePath = "https://account.mail.ru/login?page=https%3A%2F%2Fe.mail.ru%2Fmessages%2Finbox%3Futm_source%3Dportal%26utm_medium%3Dportal_navigation%26utm_campaign%3De.mail.ru&allow_external=1&from=octavius";
        private IWebDriver _driver;

        [SetUp]
        public void OpenLoginPage()
        {
            _driver = new ChromeDriver(_driverPath);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(_loginPagePath);
        }

        [Test]
        public void SubmitLogin_EmptyUsername_ReturnLoginPage()
        {
            LoginPage loginPage = CreateDefaultLoginPge();
            loginPage.TypeUsername(string.Empty);
            loginPage.SubmitLoginExpectingFailure();

            bool condition = loginPage.IsEmptyUsernameError();

            Assert.IsTrue(condition);
        }

        [Test]
        public void SubmitLogin_AccountNotExist_ReturnLoginPage()
        {
            LoginPage loginPage = CreateDefaultLoginPge();
            loginPage.TypeUsername("svggcs@mail.ru");
            loginPage.SubmitLoginExpectingFailure();

            bool condition = loginPage.IsAccountNotExistError();

            Assert.IsTrue(condition);
        }

        [Test]
        public void SubmitPassword_EmptyPassword_ReturnLoginPage()
        {
            LoginPage loginPage = CreateDefaultLoginPge();
            loginPage.TypeUsername("mail_ru.test@mail.ru");
            loginPage.SubmitLogin();
            loginPage.TypePassword(string.Empty);
            loginPage.SubmitPasswordExpectingFailure();

            bool condition = loginPage.IsEmptyPasswordError();

            Assert.IsTrue(condition);
        }

        [Test]
        public void SubmitPassword_InvalidPassword_ReturnLoginPage()
        {
            LoginPage loginPage = CreateDefaultLoginPge();
            loginPage.TypeUsername("mail_ru.test@mail.ru");
            loginPage.SubmitLogin();
            loginPage.TypePassword("invalid password");
            loginPage.SubmitPasswordExpectingFailure();

            bool condition = loginPage.IsInvalidPasswordError();

            Assert.IsTrue(condition);
        }

        [Test]
        public void LoginAs_ValidUsernameAndPassword_ReturnHomePage()
        {
            LoginPage loginPage = CreateDefaultLoginPge();
            BasePage basePage = loginPage.LoginAs("mail_ru.test@mail.ru", "158274Up");

            bool condition = basePage is HomePage;

            Assert.IsTrue(condition);
        }

        [TearDown]
        public void DriverQuit()
        {
            _driver.Quit();
        }

        private LoginPage CreateDefaultLoginPge()
        {
            return new LoginPage(_driver);
        }
    }
}
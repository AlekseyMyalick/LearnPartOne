using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using MailRuModel.Pages;

namespace MailWebDriverTests
{
    [TestFixture]
    public class LoginMailRuTests
    {
        private readonly string _username = "robert.langdon.84@mail.ru";
        private readonly string _password = "158274Up";
        private readonly string _nonExistentUsername = "svggcs@mail.ru";
        private readonly string _wrongPassword = "wrong password";
        private readonly string _emptyUsernameErrorText = "Поле «Имя аккаунта» должно быть заполнено";
        private readonly string _emptyPasswordErrorText = "Поле «Пароль» должно быть заполнено";
        private readonly string _accountNotExistErrorText = "Такой аккаунт не зарегистрирован";
        private readonly string _invalidPasswordErrorText = "Неверный пароль, попробуйте ещё раз";
        private readonly string _loginPagePath = "https://account.mail.ru/login";

        private IWebDriver _driver;

        [SetUp]
        public void OpenLoginPage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(_loginPagePath);
        }

        [Test]
        public void SubmitLogin_EmptyUsername_ReturnTrue()
        {
            LoginPage loginPage = CreateDefaultLoginPage(_driver);
            loginPage.TypeUsername(string.Empty);
            loginPage.SubmitLoginExpectingFailure();

            string actual = loginPage.GetErrorMessage();

            Assert.AreEqual(_emptyUsernameErrorText, actual);
        }

        [Test]
        public void SubmitLogin_AccountNotExist_ReturnReturnTrue()
        {
            LoginPage loginPage = CreateDefaultLoginPage(_driver);
            loginPage.TypeUsername(_nonExistentUsername);
            loginPage.SubmitLoginExpectingFailure();

            string actual = loginPage.GetErrorMessage();

            Assert.AreEqual(_accountNotExistErrorText, actual);
        }

        [Test]
        public void SubmitPassword_EmptyPassword_ReturnTrue()
        {
            LoginPage loginPage = CreateDefaultLoginPage(_driver);
            loginPage.TypeUsername(_username);
            loginPage.SubmitLogin();
            loginPage.TypePassword(string.Empty);
            loginPage.SubmitPasswordExpectingFailure();

            string actual = loginPage.GetErrorMessage();

            Assert.AreEqual(_emptyPasswordErrorText, actual);
        }

        [Test]
        public void SubmitPassword_InvalidPassword_ReturnTrue()
        {
            LoginPage loginPage = CreateDefaultLoginPage(_driver);
            loginPage.TypeUsername(_username);
            loginPage.SubmitLogin();
            loginPage.TypePassword(_wrongPassword);
            loginPage.SubmitPasswordExpectingFailure();

            string actual = loginPage.GetErrorMessage();

            Assert.AreEqual(_invalidPasswordErrorText, actual);
        }

        [Test]
        public void LoginAs_ValidUsernameAndPassword_ReturnHomePage()
        {
            LoginPage loginPage = CreateDefaultLoginPage(_driver);
            BasePage basePage = loginPage.LoginAs(_username, _password);

            bool condition = basePage is HomePage;

            Assert.IsTrue(condition);
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
        private LoginPage CreateDefaultLoginPage(IWebDriver driver)
        {
            return new LoginPage(driver);
        }
    }
}
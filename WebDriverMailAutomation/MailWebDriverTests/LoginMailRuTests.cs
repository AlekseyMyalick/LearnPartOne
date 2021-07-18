using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Mail.MailRu.Login;
using Mail.Base;
using Mail.MailRu.Home;

namespace MailWebDriverTests
{
    [TestFixture]
    public class LoginMailRuTests
    {
        public User EmptyUser => new User(string.Empty, string.Empty);

        public User NotExistUser => new User("svggcs@mail.ru", string.Empty);

        public User ValidUser => new User("robert.langdon.84@mail.ru", "158274Up");

        public User EmptyPasswordUser => new User("robert.langdon.84@mail.ru", string.Empty);

        public User InvalidUser => new User("robert.langdon.84@mail.ru", "wrong password");

        private readonly string _emptyUsernameErrorText = "Поле «Имя аккаунта» должно быть заполнено";
        private readonly string _emptyPasswordErrorText = "Поле «Пароль» должно быть заполнено";
        private readonly string _accountNotExistErrorText = "Такой аккаунт не зарегистрирован";
        private readonly string _invalidPasswordErrorText = "Неверный пароль, попробуйте ещё раз";

        private IWebDriver _driver;

        [SetUp]
        public void OpenLoginPage()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void SubmitLogin_EmptyUsername_ReturnTrue()
        {
            LoginPage loginPage = CreateDefaultLoginPage(_driver);
            loginPage.LoginAs(EmptyUser);

            string actual = loginPage.GetErrorMessage();

            Assert.AreEqual(_emptyUsernameErrorText, actual,
                $"The error message text \"{actual}\" does not match " +
                $"the expected \"{_emptyUsernameErrorText}\".");
        }

        [Test]
        public void SubmitLogin_AccountNotExist_ReturnReturnTrue()
        {
            LoginPage loginPage = CreateDefaultLoginPage(_driver);
            loginPage.LoginAs(NotExistUser);

            string actual = loginPage.GetErrorMessage();

            Assert.AreEqual(_accountNotExistErrorText, actual,
                $"The error message text \"{actual}\" does not match " +
                $"the expected \"{_accountNotExistErrorText}\".");
        }

        [Test]
        public void SubmitPassword_EmptyPassword_ReturnTrue()
        {
            LoginPage loginPage = CreateDefaultLoginPage(_driver);
            loginPage.LoginAs(EmptyPasswordUser);

            string actual = loginPage.GetErrorMessage();

            Assert.AreEqual(_emptyPasswordErrorText, actual,
                $"The error message text \"{actual}\" does not match " +
                $"the expected \"{_emptyPasswordErrorText}\".");
        }

        [Test]
        public void SubmitPassword_InvalidPassword_ReturnTrue()
        {
            LoginPage loginPage = CreateDefaultLoginPage(_driver);
            loginPage.LoginAs(InvalidUser);

            string actual = loginPage.GetErrorMessage();

            Assert.AreEqual(_invalidPasswordErrorText, actual,
                 $"The error message text \"{actual}\" does not match " +
                 $"the expected \"{_invalidPasswordErrorText}\".");
        }

        [Test]
        public void LoginAs_ValidUsernameAndPassword_ReturnHomePage()
        {
            LoginPage loginPage = CreateDefaultLoginPage(_driver);
            var page = loginPage.LoginAs(ValidUser);

            bool condition = page is HomePage;

            Assert.IsTrue(condition, "The page is not HomePage.");
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
            LoginPage loginPage = new LoginPage(driver);
            loginPage.OpenLoginPage();

            return loginPage;
        }
    }
}
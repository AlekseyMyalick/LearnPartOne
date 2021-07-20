using OpenQA.Selenium;
using NUnit.Framework;
using Mail.MailRu.Login;
using Mail.MailRu.Home;

namespace MailWebDriverTests
{
    [TestFixture]
    public class LoginMailRuTests : CommonConditions
    {
        [Test]
        public void SubmitLogin_EmptyUsername_ReturnTrue()
        {
            LoginPage loginPage = CreateDefaultLoginPage(_driver);
            loginPage.LoginAs(UserEmptyMailRu);

            bool condition = loginPage.IsErrorMessageVisible();

            Assert.IsTrue(condition, "No error message is displayed.");
        }

        [Test]
        public void SubmitLogin_AccountNotExist_ReturnReturnTrue()
        {
            LoginPage loginPage = CreateDefaultLoginPage(_driver);
            loginPage.LoginAs(UserNotExistMailRu);

            bool condition = loginPage.IsErrorMessageVisible();

            Assert.IsTrue(condition, "No error message is displayed.");
        }

        [Test]
        public void SubmitPassword_EmptyPassword_ReturnTrue()
        {
            LoginPage loginPage = CreateDefaultLoginPage(_driver);
            loginPage.LoginAs(UserEmptyPasswordMailRu);

            bool condition = loginPage.IsErrorMessageVisible();

            Assert.IsTrue(condition, "No error message is displayed.");
        }

        [Test]
        public void SubmitPassword_InvalidPassword_ReturnTrue()
        {
            LoginPage loginPage = CreateDefaultLoginPage(_driver);
            loginPage.LoginAs(UserInvalidPasswordMailRu);

            bool condition = loginPage.IsErrorMessageVisible();

            Assert.IsTrue(condition, "No error message is displayed.");
        }

        [Test]
        public void LoginAs_ValidUsernameAndPassword_ReturnHomePage()
        {
            LoginPage loginPage = CreateDefaultLoginPage(_driver);
            var page = loginPage.LoginAs(UserMailRu);

            bool condition = page is HomePage;

            Assert.IsTrue(condition, "The page is not HomePage.");
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
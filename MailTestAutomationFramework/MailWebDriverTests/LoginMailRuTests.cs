using NUnit.Framework;
using Mail.Service;
using Mail.Util;
using Mail.MailServices.MailRu.Login;
using Mail.MailServices.MailRu.Home;

namespace MailWebDriverTests
{
    [TestFixture]
    public class LoginMailRuTests : CommonConditions
    {
        [Test]
        [Category("All")]
        public void SubmitLogin_EmptyUsername_ReturnTrue()
        {
            LoginPage loginPage
                = CreateDefaultMailRuPageUtils.CreateLoginPage(_driver);
            loginPage.LoginAs(UserCreator.UserEmptyMailRu);

            bool condition = loginPage.IsErrorMessageVisible();

            Assert.IsTrue(condition, "No error message is displayed.");
        }

        [Test]
        [Category("All")]
        public void SubmitLogin_AccountNotExist_ReturnReturnTrue()
        {
            LoginPage loginPage
                = CreateDefaultMailRuPageUtils.CreateLoginPage(_driver);
            loginPage.LoginAs(UserCreator.UserNotExistMailRu);

            bool condition = loginPage.IsErrorMessageVisible();

            Assert.IsTrue(condition, "No error message is displayed.");
        }

        [Test]
        [Category("All")]
        public void SubmitPassword_EmptyPassword_ReturnTrue()
        {
            LoginPage loginPage
                = CreateDefaultMailRuPageUtils.CreateLoginPage(_driver);
            loginPage.LoginAs(UserCreator.UserEmptyPasswordMailRu);

            bool condition = loginPage.IsErrorMessageVisible();

            Assert.IsTrue(condition, "No error message is displayed.");
        }

        [Test]
        [Category("All")]
        public void SubmitPassword_InvalidPassword_ReturnTrue()
        {
            LoginPage loginPage
                = CreateDefaultMailRuPageUtils.CreateLoginPage(_driver);
            loginPage.LoginAs(UserCreator.UserInvalidPasswordMailRu);

            bool condition = loginPage.IsErrorMessageVisible();

            Assert.IsTrue(condition, "No error message is displayed.");
        }

        [Test]
        [Category("All")]
        [Category("Smoke")]
        public void LoginAs_ValidUsernameAndPassword_ReturnHomePage()
        {
            LoginPage loginPage
                = CreateDefaultMailRuPageUtils.CreateLoginPage(_driver);
            var page = loginPage.LoginAs(UserCreator.UserMailRu);

            bool condition = page is HomePage;

            Assert.IsTrue(condition, "The page is not HomePage.");
        }
    }
}
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
        public void SubmitLoginExpectingFailure_EmptyUsername_ReturnNewLoginPage()
        {
            LoginPage loginPage = CreateDefaultLoginPge();
            loginPage.TypeUsername(string.Empty);
            loginPage.SubmitLoginExpectingFailure();

            string actual = _driver.Title;

            Assert.AreEqual("Авторизация", actual);
        }

        private LoginPage CreateDefaultLoginPge()
        {
            return new LoginPage(_driver);
        }
    }
}
using OpenQA.Selenium;
using NUnit.Framework;
using MailRuPages = Mail.MailRu;
using GmailPages = Mail.Gmail;

namespace MailWebDriverTests
{
    [TestFixture]
    public class NicknameChangeTests : CommonConditions
    {
        [SetUp]
        public void SendLetterFromMailRu()
        {
            MailRuPages.Login.LoginPage loginPage = CreateDefaultMailRuLoginPage(_driver);
            var page = loginPage.LoginAs(UserMailRu);

            MailRuPages.Home.HomePage homePage
            = page as MailRuPages.Home.HomePage;

            MailRuPages.WriteLetter.WriteLetterPage writeLetter
                = homePage.OpenWriteLetterPage();

            writeLetter.WriteLetter(SendLetter);
        }


        [Test]
        public void NicknameChange_CorrectChange_ReturnTrue()
        {
            GmailPages.Login.LoginPage loginPage = CreateDefaultGmailLoginPage(_driver);
            var page = loginPage.LoginAs(UserGmail);
            GmailPages.Home.HomePage homePage = page as GmailPages.Home.HomePage;
            GmailPages.Inbox.InboxPage inboxPage = homePage.OpenInboxPage();
            inboxPage.ReplyToLastLetter(SendResponse);

            MailRuPages.Login.LoginPage loginPageMailRu = CreateDefaultMailRuLoginPage(_driver);
            var pageMailRu = loginPageMailRu.LoginAs(UserMailRu);
            MailRuPages.Home.HomePage homePageMailRu
                = pageMailRu as MailRuPages.Home.HomePage;
            MailRuPages.PersonalData.PersonalDataPage personalDataPageMailRu
                = homePageMailRu.OpenPersonalDataPage();

            personalDataPageMailRu.ChangeNickname(SendResponse.Alias);
            homePageMailRu = personalDataPageMailRu.OpenHomePage();
            personalDataPageMailRu = homePageMailRu.OpenPersonalDataPage();

            string actualNickname = personalDataPageMailRu.GetNickname();

            Assert.AreEqual(SendResponse.Alias, actualNickname,
                $"The alias \"{actualNickname}\" does not " +
                $"match the expected \"{SendResponse.Alias}\".");
        }

        [TearDown]
        public void ReplaceWithOldAlias()
        {
            MailRuPages.Login.LoginPage loginPageMailRu = CreateDefaultMailRuLoginPage(_driver);
            var pageMailRu = loginPageMailRu.LoginAs(UserMailRu);
            MailRuPages.Home.HomePage homePageMailRu
                = pageMailRu as MailRuPages.Home.HomePage;
            MailRuPages.PersonalData.PersonalDataPage personalDataPageMailRu
                = homePageMailRu.OpenPersonalDataPage();

            personalDataPageMailRu.ChangeNickname(_oldNickname);

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

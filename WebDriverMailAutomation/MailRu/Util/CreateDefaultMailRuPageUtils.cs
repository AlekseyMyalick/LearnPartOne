using Mail.MailRu.Login;
using Mail.MailRu.Home;
using Mail.MailRu.Inbox;
using Mail.MailRu.PersonalData;
using Mail.MailRu.WriteLetter;
using OpenQA.Selenium;
using Mail.Base;

namespace Mail.Util
{
    public class CreateDefaultMailRuPageUtils
    {
        /// <summary>
        /// Creates an instance of the LoginPage class.
        /// </summary>
        /// <param name="driver">An instance of the web driver.</param>
        /// <returns>Login page.</returns>
        public static LoginPage CreateLoginPage(IWebDriver driver)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.OpenLoginPage();

            return loginPage;
        }

        public static HomePage CreateHomePage(IWebDriver driver, User user)
        {
            return CreateLoginPage(driver).LoginAs(user) as HomePage;
        }

        public static InboxPage CreateInboxPage(IWebDriver driver, User user)
        {
            return CreateHomePage(driver, user).OpenInboxPage();
        }

        public static PersonalDataPage CreatePersonalDataPage(IWebDriver driver, User user)
        {
            return CreateHomePage(driver, user).OpenPersonalDataPage();
        }

        public static WriteLetterPage CreateWriteLetterPage(IWebDriver driver, User user)
        {
            return CreateHomePage(driver, user).OpenWriteLetterPage();
        }
    }
}

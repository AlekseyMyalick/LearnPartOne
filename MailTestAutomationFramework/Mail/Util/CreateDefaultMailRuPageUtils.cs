using OpenQA.Selenium;
using Mail.Base;
using Mail.MailServices.MailRu.Home;
using Mail.MailServices.MailRu.Inbox;
using Mail.MailServices.MailRu.Login;
using Mail.MailServices.MailRu.PersonalData;
using Mail.MailServices.MailRu.WriteLetter;

namespace Mail.Util
{
    /// <summary>
    /// Represents a class that implements the creation
    /// of default pages for the MailRu mail service.
    /// </summary>
    public class CreateDefaultMailRuPageUtils
    {
        /// <summary>
        /// Creates an instance of the LoginPage class.
        /// </summary>
        /// <param name="driver">Webdriver.</param>
        /// <returns>Login page.</returns>
        public static LoginPage CreateLoginPage(IWebDriver driver)
        {
            LoginPage loginPage = new LoginPage(driver);

            return loginPage;
        }

        /// <summary>
        /// Creates an instance of the HomePage class.
        /// </summary>
        /// <param name="driver">Webdriver.</param>
        /// <param name="user">User.</param>
        /// <returns>HomePage</returns>
        public static HomePage CreateHomePage(IWebDriver driver, User user)
        {
            return CreateLoginPage(driver).LoginAs(user) as HomePage;
        }

        /// <summary>
        /// Creates an instance of the InboxPage class.
        /// </summary>
        /// <param name="driver">Webdriver.</param>
        /// <param name="user">User.</param>
        /// <returns>InboxPage.</returns>
        public static InboxPage CreateInboxPage(IWebDriver driver, User user)
        {
            return CreateHomePage(driver, user).OpenInboxPage();
        }

        /// <summary>
        /// Creates an instance of the PersonalDataPage class.
        /// </summary>
        /// <param name="driver">Webdriver.</param>
        /// <param name="user">User.</param>
        /// <returns>PersonalDataPage.</returns>
        public static PersonalDataPage CreatePersonalDataPage(IWebDriver driver, User user)
        {
            return CreateHomePage(driver, user).OpenPersonalDataPage();
        }

        /// <summary>
        /// Creates an instance of the WriteLetterPage class.
        /// </summary>
        /// <param name="driver">Webdriver.</param>
        /// <param name="user">User.</param>
        /// <returns>WriteLetterPage</returns>
        public static WriteLetterPage CreateWriteLetterPage(IWebDriver driver, User user)
        {
            return CreateHomePage(driver, user).OpenWriteLetterPage();
        }
    }
}

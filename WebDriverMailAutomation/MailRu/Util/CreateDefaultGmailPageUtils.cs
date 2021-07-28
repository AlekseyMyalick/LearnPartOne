using Mail.Gmail.Login;
using Mail.Gmail.Home;
using Mail.Gmail.Inbox;
using OpenQA.Selenium;
using Mail.Base;

namespace Mail.Util
{
    /// <summary>
    /// Represents a class that implements the creation
    /// of default pages for the Gmail mail service.
    /// </summary>
    public class CreateDefaultGmailPageUtils
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
    }
}

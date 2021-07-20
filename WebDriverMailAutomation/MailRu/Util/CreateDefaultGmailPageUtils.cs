using Mail.Gmail.Login;
using Mail.Gmail.Home;
using Mail.Gmail.Inbox;
using OpenQA.Selenium;
using Mail.Base;

namespace Mail.Util
{
    public class CreateDefaultGmailPageUtils
    {
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
    }
}

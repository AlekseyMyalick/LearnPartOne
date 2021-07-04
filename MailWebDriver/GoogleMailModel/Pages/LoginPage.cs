using OpenQA.Selenium;
using Waiters;

namespace GoogleMailModel.Pages
{
    /// <summary>
    /// Represents a page describing the authorization page.
    /// </summary>
    public class LoginPage : BasePage
    {
        private readonly string _usernameXpath = "//input[@type='email']";
        private readonly string _driverTitle = "Вход";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public LoginPage(IWebDriver driver) : base(driver)
        {
            Waiter.WaitTitleContains(_driverTitle);
        }

        
    }
}

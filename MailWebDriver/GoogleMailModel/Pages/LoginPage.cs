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
        private readonly string _loginButtonXpath = "//span[text()='Далее']";
        private readonly string _passwordXpath = "//input[@type='password']";
        private readonly string _driverTitle = "Вход";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public LoginPage(IWebDriver driver) : base(driver)
        {
            Waiter.WaitTitleContains(_driverTitle);
        }

        /// <summary>
        /// Enters username.
        /// </summary>
        /// <param name="username">Username for input.</param>
        /// <returns>The same page with the entered login.</returns>
        public LoginPage TypeUsername(string username)
        {
            Waiter.WaitElementIsVisible(By.XPath(_usernameXpath));

            Driver.FindElement(By.XPath(_usernameXpath)).SendKeys(username);

            return this;
        }

        /// <summary>
        /// Presses the button sending the login.
        /// </summary>
        /// <returns>The same page with an empty password field.</returns>
        public LoginPage SubmitLogin()
        {
            Waiter.WaitElementIsVisible(By.XPath(_loginButtonXpath));

            Driver.FindElement(By.XPath(_loginButtonXpath)).Submit();

            return this;
        }

        /// <summary>
        /// Enters password.
        /// </summary>
        /// <param name="password">Password for input.</param>
        /// <returns>The same page with the entered password.</returns>
        public LoginPage TypePassword(string password)
        {
            Waiter.WaitElementIsVisible(By.XPath(_passwordXpath));

            Driver.FindElement(By.XPath(_passwordXpath)).SendKeys(password);

            return this;
        }
    }
}

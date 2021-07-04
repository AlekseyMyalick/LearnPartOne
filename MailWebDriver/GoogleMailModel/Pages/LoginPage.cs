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
        private readonly string _enterPasswordButtonXpath = "//span[text()='Далее']";
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

        /// <summary>
        /// Presses the button sending the password.
        /// </summary>
        /// <returns>Home page.</returns>
        public HomePage SubmitPassword()
        {
            Waiter.WaitElementIsVisible(By.XPath(_enterPasswordButtonXpath));

            Driver.FindElement(By.XPath(_enterPasswordButtonXpath)).Submit();

            return new HomePage(Driver);
        }

        /// <summary>
        /// Presses the button sending the password.
        /// </summary>
        /// <returns>Invalid username or password expected.</returns>
        public LoginPage SubmitPasswordExpectingFailure()
        {
            Waiter.WaitElementIsVisible(By.XPath(_enterPasswordButtonXpath));

            Driver.FindElement(By.XPath(_enterPasswordButtonXpath)).Submit();

            return new LoginPage(Driver);
        }

        /// <summary>
        /// Performs authorization.
        /// </summary>
        /// <param name="username">Username for input.</param>
        /// <param name="password">Password for input.</param>
        /// <returns>Home page.</returns>
        public HomePage LoginAs(string username, string password)
        {
            TypeUsername(username);
            SubmitLogin();
            TypePassword(password);

            return SubmitPassword();
        }
    }
}

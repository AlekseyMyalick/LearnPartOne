using OpenQA.Selenium;
using Waiters;

namespace MailRuModel.Pages
{
    /// <summary>
    /// Represents a page describing the authorization page.
    /// </summary>
    public class LoginPage : BasePage
    {
        private readonly string _usernameXpath = "//input[@name='username']";
        private readonly string _enterPasswordButtonXpath = "//span[text()='Ввести пароль']";
        private readonly string _passwordXpath = "//input[@name='password']";
        private readonly string _loginButtonXpath = "//span[text()='Войти']";
        private readonly string _driverTitle = "Авторизация";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public LoginPage(IWebDriver driver) : base(driver)
        {
            if (!_driverTitle.Equals(driver.Title))
            {
                throw new InvalidElementStateException("This is not the login page");
            }
        }

        /// <summary>
        /// Enters username.
        /// </summary>
        /// <param name="username">Username for input.</param>
        /// <returns>The same page with the entered login.</returns>
        public LoginPage TypeUsername(string username)
        {
            Waiter.WaitElementExists(By.XPath(_usernameXpath));

            Driver.FindElement(By.XPath(_usernameXpath)).SendKeys(username);

            return this;
        }
    }
}

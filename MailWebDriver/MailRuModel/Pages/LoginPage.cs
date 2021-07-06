﻿using OpenQA.Selenium;
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
        private readonly string _emptyUsernameErrorXpath = "//div[contains(@data-test-id,'error')]/small";
        private readonly string _passwordXpath = "//input[@name='password']";
        private readonly string _loginButtonXpath = "//span[text()='Войти']";
        private readonly string _emptyPasswordErrorXpath = "//div[contains(@data-test-id,'error')]/small";
        private readonly string _driverTitle = "Авторизация";

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
            Waiter.WaitElementIsVisible(By.XPath(_enterPasswordButtonXpath));

            Driver.FindElement(By.XPath(_enterPasswordButtonXpath)).Submit();

            return this;
        }

        /// <summary>
        /// Presses the button sending the login.
        /// </summary>
        /// <returns>New LoginPage.</returns>
        public LoginPage SubmitLoginExpectingFailure()
        {
            Waiter.WaitElementIsVisible(By.XPath(_enterPasswordButtonXpath));

            Driver.FindElement(By.XPath(_enterPasswordButtonXpath)).Submit();

            return new LoginPage(Driver);
        }

        /// <summary>
        /// Checks the appearance of an element when an empty username is entered.
        /// </summary>
        /// <returns>True if the element is displayed, false otherwise.</returns>
        public bool IsEmptyUsernameErrorDisplayed()
        {
            Waiter.WaitElementIsVisible(By.XPath(_emptyUsernameErrorXpath));

            return Driver.FindElement(By.XPath(_emptyUsernameErrorXpath)).Displayed;
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
            Waiter.WaitElementIsVisible(By.XPath(_loginButtonXpath));

            Driver.FindElement(By.XPath(_loginButtonXpath)).Submit();

            return new HomePage(Driver);
        }

        /// <summary>
        /// Presses the button sending the password.
        /// </summary>
        /// <returns>New LoginPage.</returns>
        public LoginPage SubmitPasswordExpectingFailure()
        {
            Waiter.WaitElementIsVisible(By.XPath(_loginButtonXpath));

            Driver.FindElement(By.XPath(_loginButtonXpath)).Submit();

            return new LoginPage(Driver);
        }

        /// <summary>
        /// Checks the appearance of an element when an empty password is entered.
        /// </summary>
        /// <returns>True if the element is displayed, false otherwise.</returns>
        public bool IsEmptyPasswordErrorDisplayed()
        {
            Waiter.WaitElementIsVisible(By.XPath(_emptyPasswordErrorXpath));

            return Driver.FindElement(By.XPath(_emptyPasswordErrorXpath)).Displayed;
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
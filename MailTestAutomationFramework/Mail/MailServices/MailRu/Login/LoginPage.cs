﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Mail.Base;
using Waiter;

namespace Mail.MailServices.MailRu.Login
{
    public class LoginPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[contains(@data-test-id,'error')]/small")]
        public IWebElement ErrorMessage;

        private readonly string _loginPagePath = "https://account.mail.ru/login";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public LoginPage(IWebDriver driver) : base(driver) { }

        public LoginPage OpenLoginPage()
        {
            Driver.Navigate().GoToUrl(_loginPagePath);

            return this;
        }

        /// <summary>
        /// Returns the error text.
        /// </summary>
        /// <returns>Error message text.</returns>
        public bool IsErrorMessageVisible()
        {
            try
            {
                new Waiter.Waiter(Driver, WaitTime)
                    .WaitElementIsVisible(By.XPath(_errorMessageXpath));

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Performs authorization.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>Returns the login window if the email address
        /// is incorrect, the password entry window if the password
        /// is incorrect, otherwise home page.</returns>
        public BasePage LoginAs(User user)
        {
            var loginAccountWindow = new LoginAccountWindow(Driver)
                .SubmitLogin(user.Email);

            if (loginAccountWindow is LoginAccountWindow)
            {
                return loginAccountWindow;
            }

            var enterPasswordWindow = (loginAccountWindow as EnterPasswordWindow)
                .SubmitPassword(user.Password);

            if (enterPasswordWindow is EnterPasswordWindow)
            {
                return enterPasswordWindow;
            }

            return enterPasswordWindow;
        }
    }
}
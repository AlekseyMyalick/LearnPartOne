using OpenQA.Selenium;
using Mail.Base;
using Waiter;
using Mail.MailServices.MailRu.Home;
using Mail.Util;

namespace Mail.MailServices.MailRu.Login
{
    /// <summary>
    /// Represents the enter password window of the login page.
    /// </summary>
    public class EnterPasswordWindow : BasePage
    {
        public IWebElement PasswordInput =>
            Driver.FindElement(By.XPath("//input[@name='password']"), WaitTime);

        public IWebElement LoginButton =>
            Driver.FindElement(By.XPath("//span[text()='Войти']"), WaitTime);

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public EnterPasswordWindow(IWebDriver driver) : base(driver)
        {
            base.WaitPageLoading();
        }

        /// <summary>
        /// Whether the title is displayed with the desired text on the page.
        /// </summary>
        /// <returns>True if the element with the text
        /// is displayed, otherwise false.</returns>
        public bool IsWindowCapTitleVisible()
        {
            try
            {
                return new WaiterWrapper(Driver, WaitTime)
                    .WaitTitleContains(HomePage.title);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Enters password.
        /// </summary>
        /// <param name="password">Password for input.</param>
        /// <returns>Enter password window.</returns>
        public EnterPasswordWindow TypePassword(string password)
        {
            PasswordInput.SendKeys(password);

            return this;
        }

        /// <summary>
        /// Presses the button sending the password.
        /// </summary>
        /// <returns>Returns the enter password window if
        /// an invalid password was entered, otherwise home page.</returns>
        public BasePage SubmitPasswordClick()
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementToBeClickable(LoginButton);

            LoginButton.Click();

            if (!IsWindowCapTitleVisible())
            {
                return new EnterPasswordWindow(Driver);
            }

            return new HomePage(Driver);
        }

        /// <summary>
        /// Fills in the password field and submits it.
        /// </summary>
        /// <param name="password">User password.</param>
        /// <returns>Returns the enter password window if
        /// an invalid password was entered, otherwise home page.</returns>
        public BasePage SubmitPassword(string password)
        {
            TypePassword(password);

            return SubmitPasswordClick();
        }
    }
}

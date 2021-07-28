using Mail.Base;
using Mail.Util;
using Waiter;
using OpenQA.Selenium;

namespace Mail.MailServices.Gmail.Login
{
    /// <summary>
    /// Represents the Login account window of the login page.
    /// </summary>
    public class LoginAccountWindow : BasePage
    {
        public IWebElement UsernameInput => Driver.FindElement(By.XPath("//input[@type='email']"), WaitTime);

        public IWebElement EnterPasswordButton => Driver.FindElement(By.XPath("//span[text()='Далее']"), WaitTime);

        private readonly string _windowCapTitleXpath = "//h1/span[@jsslot]";
        private readonly string _windowCapTitleText = "Вход";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public LoginAccountWindow(IWebDriver driver) : base(driver)
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
                return !(new WaiterWrapper(Driver, WaitTime)
                    .WaitInvisibilityOfElementWithText(By.XPath(_windowCapTitleXpath), _windowCapTitleText));
            }
            catch (WebDriverTimeoutException)
            {
                return true;
            }
        }

        /// <summary>
        /// Enters username.
        /// </summary>
        /// <param name="username">Username for input.</param>
        /// <returns>Login account window.</returns>
        public LoginAccountWindow TypeUsername(string username)
        {
            UsernameInput.SendKeys(username);

            return this;
        }

        /// <summary>
        /// Presses the button sending the login.
        /// </summary>
        /// <returns>Returns the login account window if
        /// an invalid login was entered, otherwise enter password window.</returns>
        public BasePage SubmitLoginClick()
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementToBeClickable(EnterPasswordButton);

            EnterPasswordButton.Click();

            if (IsWindowCapTitleVisible())
            {
                return new LoginAccountWindow(Driver);
            }

            return new EnterPasswordWindow(Driver);
        }

        /// <summary>
        /// Fills in the username field and clicks the submit button.
        /// </summary>
        /// <param name="username">User email.</param>
        /// <returns>Returns the login account window if
        /// an invalid login was entered, otherwise enter password window.</returns>
        public BasePage SubmitLogin(string username)
        {
            TypeUsername(username);

            return SubmitLoginClick();
        }
    }
}

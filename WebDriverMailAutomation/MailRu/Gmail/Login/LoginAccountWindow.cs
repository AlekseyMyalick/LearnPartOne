using OpenQA.Selenium;
using Mail.Base;

namespace Mail.Gmail.Login
{
    /// <summary>
    /// Represents the Login account window of the login page.
    /// </summary>
    public class LoginAccountWindow : BasePage
    {
        public IWebElement UsernameInput => Driver.FindElement(By.XPath("//input[@type='email']"));

        public IWebElement EnterPasswordButton => Driver.FindElement(By.XPath("//span[text()='Далее']"));

        private readonly string _usernameXpath = "//input[@type='email']";
        private readonly string _windowCapTitleXpath = "//h1/span[@jsslot]";
        private readonly string _windowCapTitleText = "Вход";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public LoginAccountWindow(IWebDriver driver) : base(driver)
        {
            WaitPageLoading();
        }

        /// <summary>
        /// Waiting for the login page to load.
        /// </summary>
        public override void WaitPageLoading()
        {
            base.WaitPageLoading();

            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_usernameXpath));
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
                new Waiter.Waiter(Driver, WaitTime)
                .WaitInvisibilityOfElementWithText(By.XPath(_windowCapTitleXpath), _windowCapTitleText);

                return false;
            }
            catch (System.Exception)
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

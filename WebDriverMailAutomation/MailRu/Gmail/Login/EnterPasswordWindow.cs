using OpenQA.Selenium;
using Mail.Base;
using Mail.Gmail.Home;

namespace Mail.Gmail.Login
{
    /// <summary>
    /// Represents the enter password window of the login page.
    /// </summary>
    public class EnterPasswordWindow : BasePage
    {
        public IWebElement LoginButton => Driver.FindElement(By.XPath("//span[text()='Далее']"));

        public IWebElement PasswordInput => Driver.FindElement(By.XPath("//input[@type='password']"));

        private readonly string _passwordXpath = "//input[@type='password']";
        private readonly string _windowCapTitleXpath = "//h1/span[@jsslot]";
        private readonly string _windowCapTitleText = "Добро пожаловать!";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public EnterPasswordWindow(IWebDriver driver) : base(driver)
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
                .WaitElementIsVisible(By.XPath(_passwordXpath));
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
            LoginButton.Click();

            if (IsWindowCapTitleVisible())
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

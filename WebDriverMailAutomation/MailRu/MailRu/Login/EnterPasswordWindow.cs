using OpenQA.Selenium;
using Mail.MailRu.Home;
using Mail.Base;

namespace Mail.MailRu.Login
{
    /// <summary>
    /// Represents the enter password window of the login page.
    /// </summary>
    public class EnterPasswordWindow : BasePage
    {
        private readonly string _passwordXpath = "//input[@name='password']";
        private readonly string _loginButtonXpath = "//span[text()='Войти']";
        private readonly string _windowCapTitleXpath = "//*[@data-test-id='header-text']";
        private readonly string _windowCapTitleText = "Введите пароль";

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
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_passwordXpath));

            Driver.FindElement(By.XPath(_passwordXpath)).SendKeys(password);

            return this;
        }

        /// <summary>
        /// Presses the button sending the password.
        /// </summary>
        /// <returns>Returns the enter password window if
        /// an invalid password was entered, otherwise home page.</returns>
        public BasePage SubmitPasswordClick()
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_loginButtonXpath));

            Driver.FindElement(By.XPath(_loginButtonXpath)).Submit();

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

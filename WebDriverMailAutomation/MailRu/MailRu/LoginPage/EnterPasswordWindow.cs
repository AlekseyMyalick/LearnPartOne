using Mail.MailRu;
using OpenQA.Selenium;

namespace MailRu.MailRu.LoginPage
{
    /// <summary>
    /// Represents the enter password window of the login page.
    /// </summary>
    class EnterPasswordWindow : BasePage
    {
        private readonly string _passwordXpath = "//input[@name='password']";
        private readonly string _loginButtonXpath = "//span[text()='Войти']";
        private readonly string _windowCapTitleXpath = "//*[@data-test-id='header-text']";
        private readonly string _windowCapTitleText = "Введите пароль";
        private readonly int _waitTime = 20000;

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

            new Waiter.Waiter(Driver, _waitTime)
                .WaitElementIsVisible(By.XPath(_passwordXpath));
        }

        /// <summary>
        /// Returns the title of the window.
        /// </summary>
        /// <returns>Title text.</returns>
        public string GetWindowCapTitleText()
        {
            new Waiter.Waiter(Driver, _waitTime)
                .WaitElementIsVisible(By.XPath(_windowCapTitleXpath));

            return Driver.FindElement(By.XPath(_windowCapTitleXpath)).Text;
        }

        /// <summary>
        /// Enters password.
        /// </summary>
        /// <param name="password">Password for input.</param>
        /// <returns>Enter password window.</returns>
        public EnterPasswordWindow TypePassword(string password)
        {
            new Waiter.Waiter(Driver, _waitTime)
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
            new Waiter.Waiter(Driver, _waitTime)
                .WaitElementIsVisible(By.XPath(_loginButtonXpath));

            Driver.FindElement(By.XPath(_loginButtonXpath)).Submit();

            if (GetWindowCapTitleText() == _windowCapTitleText)
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

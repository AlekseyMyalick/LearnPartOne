using Mail.MailRu;
using OpenQA.Selenium;

namespace MailRu.MailRu.LoginPage
{
    /// <summary>
    /// Represents the Login account window of the login page.
    /// </summary>
    public class LoginAccountWindow : BasePage
    {
        private readonly string _usernameXpath = "//input[@name='username']";
        private readonly string _enterPasswordButtonXpath = "//span[text()='Ввести пароль']";
        private readonly string _windowCapTitleXpath = "//*[@data-test-id='header-text']";
        private readonly string _windowCapTitleText = "Войти в аккаунт";
        private readonly int _waitTime = 20000;

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

            new Waiter.Waiter(Driver, _waitTime)
                .WaitElementIsVisible(By.XPath(_usernameXpath));
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
        /// Enters username.
        /// </summary>
        /// <param name="username">Username for input.</param>
        /// <returns>Login account window.</returns>
        public LoginAccountWindow TypeUsername(string username)
        {
            new Waiter.Waiter(Driver, _waitTime)
                .WaitElementIsVisible(By.XPath(_usernameXpath));

            Driver.FindElement(By.XPath(_usernameXpath)).SendKeys(username);

            return this;
        }

        /// <summary>
        /// Presses the button sending the login.
        /// </summary>
        /// <returns>Returns the login account window if
        /// an invalid login was entered, otherwise enter password window.</returns>
        public BasePage SubmitLoginClick()
        {
            new Waiter.Waiter(Driver, _waitTime)
                .WaitElementIsVisible(By.XPath(_enterPasswordButtonXpath));

            Driver.FindElement(By.XPath(_enterPasswordButtonXpath)).Submit();

            if (GetWindowCapTitleText() == _windowCapTitleText)
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

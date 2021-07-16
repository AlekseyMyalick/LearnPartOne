using Mail.Base;
using MailRu.MailRu.LoginPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Mail.MailRu.LoginPage
{
    public class LoginPage : BasePage
    {
        private readonly string _errorMessageXpath = "//div[contains(@data-test-id,'error')]/small";
        private readonly string _loginPagePath = "https://account.mail.ru/login";
        private readonly int _waitTime = 20000;

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void OpenLoginPage()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(_loginPagePath);
        }

        /// <summary>
        /// Returns the error text.
        /// </summary>
        /// <returns>Error message text.</returns>
        public string GetErrorMessage()
        {
            new Waiter.Waiter(Driver, _waitTime)
                .WaitElementIsVisible(By.XPath(_errorMessageXpath));

            string errorMessage = Driver.FindElement(By.XPath(_errorMessageXpath))
                .Text;

            return errorMessage;
        }

        /// <summary>
        /// Performs authorization.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>Home page.</returns>
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

            return new HomePage(Driver);
        }
    }
}

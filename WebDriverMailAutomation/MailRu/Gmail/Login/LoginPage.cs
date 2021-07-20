using OpenQA.Selenium;
using Mail.Base;

namespace Mail.Gmail.Login
{
    /// <summary>
    /// Represents a page describing the authorization page.
    /// </summary>
    public class LoginPage : BasePage
    {
        private readonly string _loginPagePath = "https://accounts.google.com/ServiceLogin/identifier?passive=1209600&continue=https%3A%2F%2Faccounts.google.com%2Fb%2F0%2FAddMailService&followup=https%3A%2F%2Faccounts.google.com%2Fb%2F0%2FAddMailService&flowName=GlifWebSignIn&flowEntry=ServiceLogin";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public LoginPage(IWebDriver driver) : base(driver)
        {
            WaitPageLoading();
        }

        /// <summary>
        /// Opens the login page.
        /// </summary>
        /// <returns>Login page.</returns>
        public LoginPage OpenLoginPage()
        {
            Driver.Navigate().GoToUrl(_loginPagePath);

            return this;
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

using OpenQA.Selenium;
using NLog;
using Mail.Base;

namespace Mail.Gmail.Login
{
    /// <summary>
    /// Represents a page describing the authorization page.
    /// </summary>
    public class LoginPage : BasePage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly string _loginPagePath = "https://accounts.google.com/ServiceLogin/identifier?passive=1209600&continue=https%3A%2F%2Faccounts.google.com%2Fb%2F0%2FAddMailService&followup=https%3A%2F%2Faccounts.google.com%2Fb%2F0%2FAddMailService&flowName=GlifWebSignIn&flowEntry=ServiceLogin";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public LoginPage(IWebDriver driver) : base(driver)
        {
            OpenLoginPage();

            WaitPageLoading();
        }

        /// <summary>
        /// Opens the login page.
        /// </summary>
        /// <returns>Login page.</returns>
        private void OpenLoginPage()
        {
            Driver.Navigate().GoToUrl(_loginPagePath);

            _logger.Info("Gmail mail login page is open.");
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
                _logger.Error($"An invalid username was entered: {user.Email}.");

                return loginAccountWindow;
            }

            var enterPasswordWindow = (loginAccountWindow as EnterPasswordWindow)
                .SubmitPassword(user.Password);

            if (enterPasswordWindow is EnterPasswordWindow)
            {
                _logger.Error($"An invalid password was entered: {user.Password}.");

                return enterPasswordWindow;
            }

            _logger.Info($"The user logged in with" +
                $" the login: {user.Email}, password: {user.Password}.");

            return enterPasswordWindow;
        }
    }
}

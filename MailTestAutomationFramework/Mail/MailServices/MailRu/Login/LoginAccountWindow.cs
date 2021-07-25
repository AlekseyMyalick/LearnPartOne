using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Mail.Base;
using Waiter;

namespace Mail.MailServices.MailRu.Login
{
    public class LoginAccountWindow : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@name='username']")]
        public IWebElement UsernameInput;

        [FindsBy(How = How.XPath, Using = "//span[text()='Ввести пароль']")]
        public IWebElement EnterPasswordButton;

        [FindsBy(How = How.XPath, Using = "//*[@data-test-id='header-text']")]
        public IWebElement WindowCapTitle;

        private readonly string _windowCapTitleText = "Войти в аккаунт";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public LoginAccountWindow(IWebDriver driver) : base(driver)
        {
            base.WaitPageLoading();
            PageFactory.InitElements(Driver, this);
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
                new WaiterWrapper(Driver, WaitTime).WaitInvisibilityOfElementWithText(
                    typeof(LoginAccountWindow),
                    nameof(WindowCapTitle),
                    _windowCapTitleText);

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
            new WaiterWrapper(Driver, WaitTime).WaitElementIsVisible(
                typeof(LoginAccountWindow),
                nameof(UsernameInput));

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
            new WaiterWrapper(Driver, WaitTime).WaitElementToBeClickable(
               typeof(LoginAccountWindow),
               nameof(EnterPasswordButton));

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

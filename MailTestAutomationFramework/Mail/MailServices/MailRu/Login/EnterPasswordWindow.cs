using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Mail.Base;
using Waiter;

namespace Mail.MailServices.MailRu.Login
{
    public class EnterPasswordWindow : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        public IWebElement PasswordInput;

        [FindsBy(How = How.XPath, Using = "//span[text()='Войти']")]
        public IWebElement LoginButton;

        [FindsBy(How = How.XPath, Using = "//*[@data-test-id='header-text']")]
        public IWebElement WindowCapTitle;

        private readonly string _windowCapTitleText = "Введите пароль";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public EnterPasswordWindow(IWebDriver driver) : base(driver)
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
        /// Enters password.
        /// </summary>
        /// <param name="password">Password for input.</param>
        /// <returns>Enter password window.</returns>
        public EnterPasswordWindow TypePassword(string password)
        {
            new WaiterWrapper(Driver, WaitTime).WaitElementIsVisible(
                typeof(EnterPasswordWindow),
                nameof(PasswordInput));

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
            new WaiterWrapper(Driver, WaitTime).WaitElementToBeClickable(
                typeof(EnterPasswordWindow),
                nameof(LoginButton));

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

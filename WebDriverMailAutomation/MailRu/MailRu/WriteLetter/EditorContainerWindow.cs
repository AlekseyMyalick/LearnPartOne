using Mail.Base;
using OpenQA.Selenium;

namespace Mail.MailRu.WriteLetter
{
    /// <summary>
    /// Represents a class that describes a container editor window.
    /// </summary>
    class EditorContainerWindow : BasePage
    {
        private readonly string _sendLetterButton = "//span[text()='Отправить']";
        private readonly string _letterXpath = "//br/parent::div";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Web driver.</param>
        public EditorContainerWindow(IWebDriver driver) : base(driver)
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
                .WaitElementIsVisible(By.XPath(_sendLetterButton));
        }

        /// <summary>
        /// Enters the text of the letter.
        /// </summary>
        /// <param name="letterText">Text of the letter</param>
        /// <returns>Editor container window.</returns>
        public EditorContainerWindow TypeLetter(string letterText)
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_letterXpath));

            Driver.FindElement(By.XPath(_letterXpath)).SendKeys(letterText);

            return this;
        }

        /// <summary>
        /// Presses the send letter button.
        /// </summary>
        /// <returns>Editor container window.</returns>
        public EditorContainerWindow SubmitLetter()
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementToBeClickable(By.XPath(_sendLetterButton));

            Driver.FindElement(By.XPath(_sendLetterButton)).Click();

            return this;
        }
    }
}

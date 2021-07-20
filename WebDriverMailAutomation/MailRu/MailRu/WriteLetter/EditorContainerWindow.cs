using Mail.Base;
using OpenQA.Selenium;

namespace Mail.MailRu.WriteLetter
{
    /// <summary>
    /// Represents a class that describes a container editor window.
    /// </summary>
    class EditorContainerWindow : BasePage
    {
        public IWebElement SendLetterButton => Driver.FindElement(By.XPath("//span[text()='Отправить']"));

        public IWebElement Letter => Driver.FindElement(By.XPath("//br/parent::div"));

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
        }

        /// <summary>
        /// Enters the text of the letter.
        /// </summary>
        /// <param name="letterText">Text of the letter</param>
        /// <returns>Editor container window.</returns>
        public EditorContainerWindow TypeLetter(string letterText)
        {
            Letter.SendKeys(letterText);

            return this;
        }

        /// <summary>
        /// Presses the send letter button.
        /// </summary>
        /// <returns>Editor container window.</returns>
        public EditorContainerWindow SubmitLetter()
        {
            SendLetterButton.Click();

            return this;
        }
    }
}

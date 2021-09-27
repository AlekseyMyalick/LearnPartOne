using OpenQA.Selenium;
using Mail.Base;
using Waiter;
using Mail.Util;

namespace Mail.MailServices.MailRu.WriteLetter
{
    /// <summary>
    /// Represents a class that describes a container editor window.
    /// </summary>
    class EditorContainerWindow : BasePage
    {
        public IWebElement SendLetterButton => Driver.FindElement(By.XPath("//span[text()='Отправить']"), WaitTime);

        public IWebElement Letter => Driver.FindElement(By.XPath("//br/parent::div"), WaitTime);

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Web driver.</param>
        public EditorContainerWindow(IWebDriver driver) : base(driver)
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
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementIsVisible(Letter);

            Letter.SendKeys(letterText);

            return this;
        }

        /// <summary>
        /// Presses the send letter button.
        /// </summary>
        /// <returns>Editor container window.</returns>
        public EditorContainerWindow SubmitLetter()
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementToBeClickable(SendLetterButton);

            SendLetterButton.Click();

            return this;
        }
    }
}

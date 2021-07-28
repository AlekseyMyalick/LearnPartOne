using Mail.Base;
using Mail.Util;
using Waiter;
using OpenQA.Selenium;

namespace Mail.MailServices.Gmail.Inbox
{
    /// <summary>
    /// Represents a class that describes a letter window.
    /// </summary>
    public class LetterWindow : BasePage
    {
        public IWebElement LetterText => Driver.FindElement(By.XPath("//div[@class='gs']//div[@class='a3s aiL ']/div[2]/div[1]"), WaitTime);

        public IWebElement ReplyButton => Driver.FindElement(By.XPath("//span[@role='link'][text()='Ответить']"), WaitTime);

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public LetterWindow(IWebDriver driver) : base(driver)
        {
            base.WaitPageLoading();
        }

        /// <summary>
        /// Returns the text of the letter.
        /// </summary>
        /// <returns>Text of the letter.</returns>
        public string GetLetterText()
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementIsVisible(LetterText);

            return LetterText.Text;
        }

        /// <summary>
        /// Opens a page for responding to a letter.
        /// </summary>
        /// <returns>Reply window.</returns>
        public ReplyWindow OpenReplyWindow()
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementToBeClickable(ReplyButton);

            ReplyButton.Click();

            return new ReplyWindow(Driver);
        }
    }
}

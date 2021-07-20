using OpenQA.Selenium;
using Mail.Base;

namespace Mail.Gmail.Inbox
{
    /// <summary>
    /// Represents a class that describes a letter window.
    /// </summary>
    public class LetterWindow : BasePage
    {
        public IWebElement LetterText => Driver.FindElement(By.XPath("//div[@class='gs']//div[@class='a3s aiL ']/div[2]/div[1]"));

        public IWebElement ReplyButton => Driver.FindElement(By.XPath("//span[@role='link'][text()='Ответить']"));

        private readonly string _replyButtonXpath = "//span[@role='link'][text()='Ответить']";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public LetterWindow(IWebDriver driver) : base(driver)
        {
            WaitPageLoading();
        }

        /// <summary>
        /// Waiting for the home page to load.
        /// </summary>
        public override void WaitPageLoading()
        {
            base.WaitPageLoading();

            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementToBeClickable(By.XPath(_replyButtonXpath));
        }

        /// <summary>
        /// Returns the text of the letter.
        /// </summary>
        /// <returns>Text of the letter.</returns>
        public string GetLetterText()
        {
            string actualLetterText = LetterText.Text;

            return actualLetterText;
        }

        /// <summary>
        /// Opens a page for responding to a letter.
        /// </summary>
        /// <returns>Reply window.</returns>
        public ReplyWindow OpenReplyWindow()
        {
            ReplyButton.Click();

            return new ReplyWindow(Driver);
        }
    }
}

using OpenQA.Selenium;
using Mail.Base;

namespace Mail.Gmail.Inbox
{
    /// <summary>
    /// Represents a class that describes a letter window.
    /// </summary>
    public class LetterWindow : BasePage
    {
        private readonly string _letterTextXpath = "//div[@class='gs']//div[@class='a3s aiL ']/div[2]/div[1]";
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
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_letterTextXpath));

            string actualLetterText = Driver.FindElement(By
                .XPath(_letterTextXpath))
                .Text;

            return actualLetterText;
        }

        /// <summary>
        /// Opens a page for responding to a letter.
        /// </summary>
        /// <returns>Reply window.</returns>
        public ReplyWindow OpenReplyWindow()
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_replyButtonXpath));

            Driver.FindElement(By.XPath(_replyButtonXpath)).Click();

            return new ReplyWindow(Driver);
        }
    }
}

using OpenQA.Selenium;
using Waiters;

namespace MailRuModel.Pages
{
    public class InboxPage : BasePage
    {
        private readonly string _lastIncomingLetterXpath = "//a[contains(@class, 'letter-list')][1]";
        private readonly string _showHiddenPartButtonXpath = "//div[@class='letter__body']//span[contains(@class, 'wrapper')][1]";
        private readonly string _driverTitle = "Входящие";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public InboxPage(IWebDriver driver) : base(driver)
        {
            PageLoading();
        }

        /// <summary>
        /// Waiting for the inbox page to load.
        /// </summary>
        public override void PageLoading()
        {
            Waiter.WaitTitleContains(_driverTitle);
        }

        /// <summary>
        /// Opens the last letter that arrived.
        /// </summary>
        /// <returns>Inbox page.</returns>
        public InboxPage OpenLastIncomingLetter()
        {
            Waiter.WaitElementIsVisible(By.XPath(_lastIncomingLetterXpath));

            Driver.FindElement(By.XPath(_lastIncomingLetterXpath)).Click();

            return this;
        }

        /// <summary>
        /// Opens a hidden part of the message reply window.
        /// </summary>
        /// <returns>Inbox page.</returns>
        public InboxPage OpenHiddenPartReplyWindow()
        {
            Waiter.WaitElementIsVisible(By.XPath(_showHiddenPartButtonXpath));

            Driver.FindElement(By.XPath(_showHiddenPartButtonXpath)).Click();

            return this;
        }
    }
}

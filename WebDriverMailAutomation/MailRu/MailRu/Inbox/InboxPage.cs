using Mail.Base;
using OpenQA.Selenium;

namespace Mail.MailRu.Inbox
{
    /// <summary>
    /// It is a page describing the inbox page.
    /// </summary>
    public class InboxPage : BasePage
    {
        public IWebElement LastIncomingLetter => Driver.FindElement(By.XPath("//a[contains(@class, 'letter-list')][1]"));

        private readonly string _lastIncomingLetterXpath = "//a[contains(@class, 'letter-list')][1]";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public InboxPage(IWebDriver driver) : base(driver)
        {
            WaitPageLoading();
        }

        /// <summary>
        /// Waiting for the inbox page to load.
        /// </summary>
        public override void WaitPageLoading()
        {
            base.WaitPageLoading();
        }

        /// <summary>
        /// Opens the last letter that arrived.
        /// </summary>
        /// <returns>Letter window.</returns>
        public LetterWindow OpenLastIncomingLetter()
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_lastIncomingLetterXpath));

            LastIncomingLetter.Click();

            return new LetterWindow(Driver);
        }

        /// <summary>
        /// Returns the alias from the last email response.
        /// </summary>
        /// <returns>Alias.</returns>
        public string GetAliasFromReplyLastLetter()
        {
            OpenLastIncomingLetter();

            return new LetterWindow(Driver).GetAliasFromReply();
        }
    }
}

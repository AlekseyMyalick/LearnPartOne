using OpenQA.Selenium;
using NLog;
using Mail.Base;
using Waiter;
using Mail.Util;

namespace Mail.MailServices.MailRu.Inbox
{
    /// <summary>
    /// It is a page describing the inbox page.
    /// </summary>
    public class InboxPage : BasePage
    {
        public IWebElement LastIncomingLetter => Driver.FindElement(By.XPath("//a[contains(@class, 'letter-list')][1]"), WaitTime);

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public InboxPage(IWebDriver driver) : base(driver)
        {
            WaitPageLoading();
        }

        /// <summary>
        /// Opens the last letter that arrived.
        /// </summary>
        /// <returns>Letter window.</returns>
        public LetterWindow OpenLastIncomingLetter()
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementToBeClickable(LastIncomingLetter);

            LastIncomingLetter.Click();

            _logger.Info("The last incoming letter is open.");

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

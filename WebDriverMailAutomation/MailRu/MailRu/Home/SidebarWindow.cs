using OpenQA.Selenium;
using Mail.MailRu.WriteLetter;
using Mail.MailRu.Inbox;
using Mail.Base;

namespace Mail.MailRu.Home
{
    /// <summary>
    /// Represents the sidebar window on the home page.
    /// </summary>
    public class SidebarWindow : BasePage
    {
        private readonly string _inboxButtonXpath = "//div[text()='Входящие']";
        private readonly string _writeLetterButton = "//span[text()='Написать письмо']";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public SidebarWindow(IWebDriver driver) : base(driver)
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
                .WaitElementIsVisible(By.XPath(_writeLetterButton));
        }

        /// <summary>
        /// Opens the page for writing a letter.
        /// </summary>
        /// <returns>Write letter page.</returns>
        public WriteLetterPage OpenWriteLetterPage()
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_writeLetterButton));

            Driver.FindElement(By.XPath(_writeLetterButton)).Click();

            return new WriteLetterPage(Driver);
        }

        /// <summary>
        /// Opens the inbox page.
        /// </summary>
        /// <returns>Inbox page.</returns>
        public InboxPage OpenInboxPage()
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_inboxButtonXpath));

            Driver.FindElement(By.XPath(_inboxButtonXpath)).Click();

            return new InboxPage(Driver);
        }
    }
}

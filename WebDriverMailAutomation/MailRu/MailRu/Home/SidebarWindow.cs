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
        public IWebElement InboxButton => Driver.FindElement(By.XPath("//div[text()='Входящие']"));

        public IWebElement WriteLetterButton => Driver.FindElement(By.XPath("//span[text()='Написать письмо']"));

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
        }

        /// <summary>
        /// Opens the page for writing a letter.
        /// </summary>
        /// <returns>Write letter page.</returns>
        public WriteLetterPage OpenWriteLetterPage()
        {
            WriteLetterButton.Click();

            return new WriteLetterPage(Driver);
        }

        /// <summary>
        /// Opens the inbox page.
        /// </summary>
        /// <returns>Inbox page.</returns>
        public InboxPage OpenInboxPage()
        {
            InboxButton.Click();

            return new InboxPage(Driver);
        }
    }
}

using OpenQA.Selenium;
using Mail.Base;
using Waiter;
using Mail.Util;
using Mail.MailServices.MailRu.WriteLetter;
using Mail.MailServices.MailRu.Inbox;

namespace Mail.MailServices.MailRu.Home
{
    /// <summary>
    /// Represents the sidebar window on the home page.
    /// </summary>
    public class SidebarWindow : BasePage
    {
        public IWebElement InboxButton => Driver.FindElement(By.XPath("//div[text()='Входящие']"), WaitTime);

        public IWebElement WriteLetterButton => Driver.FindElement(By.XPath("//span[text()='Написать письмо']"), WaitTime);

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public SidebarWindow(IWebDriver driver) : base(driver)
        {
            base.WaitPageLoading();
        }

        /// <summary>
        /// Opens the page for writing a letter.
        /// </summary>
        /// <returns>Write letter page.</returns>
        public WriteLetterPage OpenWriteLetterPage()
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementToBeClickable(WriteLetterButton);

            WriteLetterButton.Click();

            return new WriteLetterPage(Driver);
        }

        /// <summary>
        /// Opens the inbox page.
        /// </summary>
        /// <returns>Inbox page.</returns>
        public InboxPage OpenInboxPage()
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementToBeClickable(InboxButton);

            InboxButton.Click();

            return new InboxPage(Driver);
        }
    }
}

using Mail.Base;
using Mail.MailServices.Gmail.Inbox;
using Mail.Util;
using Waiter;
using OpenQA.Selenium;

namespace Mail.MailServices.Gmail.Home
{
    /// <summary>
    /// Represents the sidebar window on the home page.
    /// </summary>
    public class SidebarWindow : BasePage
    {
        public IWebElement InboxButton => Driver.FindElement(By.XPath("//a[text()='Входящие']/parent::span"), WaitTime);

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public SidebarWindow(IWebDriver driver) : base(driver)
        {
            base.WaitPageLoading();
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

using OpenQA.Selenium;
using Mail.Base;
using Mail.Gmail.Inbox;

namespace Mail.Gmail.Home
{
    /// <summary>
    /// Represents the sidebar window on the home page.
    /// </summary>
    public class SidebarWindow : BasePage
    {
        public IWebElement InboxButton => Driver.FindElement(By.XPath("//a[text()='Входящие']/parent::span"));

        private readonly string _inboxButtonXpath = "//a[text()='Входящие']/parent::span";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public SidebarWindow(IWebDriver driver) : base(driver)
        {
            WaitPageLoading();
        }

        /// <summary>
        /// Waiting for the home page to load.
        /// </summary>
        public override void WaitPageLoading()
        {
            base.WaitPageLoading();
        }

        /// <summary>
        /// Opens the inbox page.
        /// </summary>
        /// <returns>Inbox page.</returns>
        public InboxPage OpenInboxPage()
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_inboxButtonXpath));

            InboxButton.Click();

            return new InboxPage(Driver);
        }
    }
}

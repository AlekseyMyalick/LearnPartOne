using OpenQA.Selenium;
using Waiters;

namespace GoogleMailModel.Pages
{
    /// <summary>
    /// It is a page describing the home page.
    /// </summary>
    public class HomePage : BasePage
    {
        private readonly string _inboxButton = "//a[text()='Входящие']/parent::span";
        private readonly string _driverTitle = "Gmail";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public HomePage(IWebDriver driver) : base(driver)
        {
            PageLoading();
        }

        /// <summary>
        /// Waiting for the home page to load.
        /// </summary>
        public override void PageLoading()
        {
            Waiter.WaitTitleContains(_driverTitle);
        }

        /// <summary>
        /// Opens the inbox page.
        /// </summary>
        /// <returns>Inbox page.</returns>
        public InboxPage OpenInboxPage()
        {
            Waiter.WaitElementIsVisible(By.XPath(_inboxButton));

            Driver.FindElement(By.XPath(_inboxButton)).Click();

            return new InboxPage(Driver);
        }
    }
}

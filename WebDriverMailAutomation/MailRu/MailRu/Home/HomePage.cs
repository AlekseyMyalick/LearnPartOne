using Mail.MailRu.WriteLetter;
using Mail.MailRu.Inbox;
using OpenQA.Selenium;
using NLog;
using Mail.MailRu.PersonalData;
using Mail.Base;

namespace Mail.MailRu.Home
{
    /// <summary>
    /// It is a page describing the home page.
    /// </summary>
    public class HomePage : BasePage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly string _sidebarXpath = "//div[contains(@class, 'full sidebar')]";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public HomePage(IWebDriver driver) : base(driver)
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
                .WaitElementIsVisible(By.XPath(_sidebarXpath));
        }

        /// <summary>
        /// Opens the page for writing a letter.
        /// </summary>
        /// <returns>Write letter page.</returns>
        public WriteLetterPage OpenWriteLetterPage()
        {
            _logger.Info("Open the write a letter page.");

            return new SidebarWindow(Driver).OpenWriteLetterPage();
        }

        /// <summary>
        /// Opens a personal data page.
        /// </summary>
        /// <returns>Personal data page.</returns>
        public PersonalDataPage OpenPersonalDataPage()
        {
            _logger.Info("Open the personal data page.");

            return new UserDataSidebarWindow(Driver).OpenPersonalDataPage();
        }

        /// <summary>
        /// Opens an incoming mail window.
        /// </summary>
        /// <returns>Inbox page.</returns>
        public InboxPage OpenInboxPage()
        {
            _logger.Info("Open the inbox page.");

            return new SidebarWindow(Driver).OpenInboxPage();
        }
    }
}

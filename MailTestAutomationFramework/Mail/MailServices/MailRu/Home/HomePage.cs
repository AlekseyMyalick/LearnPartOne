using OpenQA.Selenium;
using NLog;
using Mail.Base;
using Mail.MailServices.MailRu.Inbox;
using Mail.MailServices.MailRu.WriteLetter;
using Mail.MailServices.MailRu.PersonalData;

namespace Mail.MailServices.MailRu.Home
{
    /// <summary>
    /// It is a page describing the home page.
    /// </summary>
    public class HomePage : BasePage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public HomePage(IWebDriver driver) : base(driver)
        {
            base.WaitPageLoading();
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

using OpenQA.Selenium;
using Waiters;

namespace MailRuModel.Pages
{
    /// <summary>
    /// It is a page describing the home page.
    /// </summary>
    public class HomePage : BasePage
    {
        private readonly string _openSidebarButtonXpath = "//div[contains(@class, 'auth svelte')]//span[contains(@class, 'dropdown')]";
        private readonly string _inboxButtonXpath = "//div[text()='Входящие']";
        private readonly string _personalDataSectionXpath = "//div[text()='Личные данные']/parent::a";
        private readonly string _writeLetterButton = "//span[text()='Написать письмо']";
        private readonly string _driverTitle = "Почта Mail.ru";

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
        /// Opens the page for writing a letter.
        /// </summary>
        /// <returns>Write letter page.</returns>
        public WriteLetterPage OpenWriteLetterPage()
        {
            Waiter.WaitElementIsVisible(By.XPath(_writeLetterButton));

            Driver.FindElement(By.XPath(_writeLetterButton)).Click();

            return new WriteLetterPage(Driver);
        }

        /// <summary>
        /// Opens the side panel.
        /// </summary>
        /// <returns>Home page.</returns>
        public HomePage OpenSidebar()
        {
            Waiter.WaitElementIsVisible(By.XPath(_openSidebarButtonXpath));

            Driver.FindElement(By.XPath(_openSidebarButtonXpath)).Click();

            return this;
        }

        /// <summary>
        /// Selects the personal data section in the sidebar.
        /// </summary>
        /// <returns>Personal data page.</returns>
        public PersonalDataPage SelectPersonalDataSection()
        {
            Waiter.WaitElementIsVisible(By.XPath(_personalDataSectionXpath));

            Driver.FindElement(By.XPath(_personalDataSectionXpath)).Click();

            return new PersonalDataPage(Driver);
        }

        /// <summary>
        /// Opens a personal data page.
        /// </summary>
        /// <returns>Personal data page.</returns>
        public PersonalDataPage OpenPersonalDataPage()
        {
            OpenSidebar();

            return SelectPersonalDataSection();
        }

        /// <summary>
        /// Opens an incoming mail window.
        /// </summary>
        /// <returns>Inbox page.</returns>
        public InboxPage OpenInboxPage()
        {
            Waiter.WaitElementIsVisible(By.XPath(_inboxButtonXpath));

            Driver.FindElement(By.XPath(_inboxButtonXpath)).Click();

            return new InboxPage(Driver);
        }
    }
}

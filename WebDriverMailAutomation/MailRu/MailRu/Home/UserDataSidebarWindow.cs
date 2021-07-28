using Mail.Base;
using Mail.MailRu.PersonalData;
using OpenQA.Selenium;

namespace Mail.MailRu.Home
{
    /// <summary>
    /// Represents the user data sidebar window on the home page.
    /// </summary>
    public class UserDataSidebarWindow : BasePage
    {
        public IWebElement PersonalDataSection => Driver.FindElement(By.XPath("//div[text()='Личные данные']/parent::a"));

        public IWebElement OpenSidebarButton => Driver.FindElement(By.XPath("//div[contains(@class, 'auth svelte')]//span[contains(@class, 'dropdown')]"));

        private readonly string _openSidebarButtonXpath = "//div[contains(@class, 'auth svelte')]//span[contains(@class, 'dropdown')]";
        private readonly string _personalDataSectionXpath = "//div[text()='Личные данные']/parent::a";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public UserDataSidebarWindow(IWebDriver driver) : base(driver)
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
                .WaitElementIsVisible(By.XPath(_openSidebarButtonXpath));
        }

        /// <summary>
        /// Opens the side panel.
        /// </summary>
        /// <returns>User data sidebar window.</returns>
        public UserDataSidebarWindow OpenSidebar()
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_openSidebarButtonXpath));

            OpenSidebarButton.Click();

            return this;
        }

        /// <summary>
        /// Selects the personal data section in the sidebar.
        /// </summary>
        /// <returns>Personal data page.</returns>
        public PersonalDataPage SelectPersonalDataSection()
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_personalDataSectionXpath));

            PersonalDataSection.Click();

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
    }
}

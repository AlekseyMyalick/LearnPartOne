using OpenQA.Selenium;
using Mail.Base;
using Waiter;
using Mail.Util;
using Mail.MailServices.MailRu.PersonalData;

namespace Mail.MailServices.MailRu.Home
{
    /// <summary>
    /// Represents the user data sidebar window on the home page.
    /// </summary>
    public class UserDataSidebarWindow : BasePage
    {
        public IWebElement PersonalDataSection =>
            Driver.FindElement(By.XPath("//div[text()='Личные данные']/parent::a"), WaitTime);

        public IWebElement OpenSidebarButton =>
            Driver.FindElement(By.XPath("//div[contains(@class, 'auth svelte')]//span[contains(@class, 'dropdown')]"), WaitTime);

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public UserDataSidebarWindow(IWebDriver driver) : base(driver)
        {
            base.WaitPageLoading();
        }

        /// <summary>
        /// Opens the side panel.
        /// </summary>
        /// <returns>User data sidebar window.</returns>
        public UserDataSidebarWindow OpenSidebar()
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementToBeClickable(OpenSidebarButton);

            OpenSidebarButton.Click();

            return this;
        }

        /// <summary>
        /// Selects the personal data section in the sidebar.
        /// </summary>
        /// <returns>Personal data page.</returns>
        public PersonalDataPage SelectPersonalDataSection()
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementToBeClickable(PersonalDataSection);

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

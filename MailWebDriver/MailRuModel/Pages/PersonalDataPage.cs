using OpenQA.Selenium;
using Waiters;

namespace MailRuModel.Pages
{
    class PersonalDataPage : BasePage
    {
        private readonly string _driverTitle = "Личные данные";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public PersonalDataPage(IWebDriver driver) : base(driver)
        {
            PageLoading();
        }

        /// <summary>
        /// Waiting for the persanal data page to load.
        /// </summary>
        public override void PageLoading()
        {
            Waiter.WaitTitleContains(_driverTitle);
        }
    }
}

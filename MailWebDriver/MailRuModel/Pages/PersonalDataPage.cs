using OpenQA.Selenium;
using Waiters;

namespace MailRuModel.Pages
{
    /// <summary>
    /// Represents a page describing the personal data page.
    /// </summary>
    public class PersonalDataPage : BasePage
    {
        private readonly string _nicknameFieldXpath = "//input[@id='nickname']";
        private readonly string _nicknameAttribut = "value";
        private readonly string _saveButtonXpath= "//span[text()='Сохранить']";
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

        /// <summary>
        /// Returns nickname.
        /// </summary>
        /// <returns>Nickname</returns>
        public string GetNickname()
        {
            Waiter.WaitElementIsVisible(By.XPath(_nicknameFieldXpath));

            string nickname = Driver.FindElement(By.XPath(_nicknameFieldXpath))
                .GetAttribute(_nicknameAttribut);

            return nickname;
        }

        /// <summary>
        /// Introduces a new nickname.
        /// </summary>
        /// <param name="nickname">New nickname.</param>
        /// <returns>Personal data page.</returns>
        public PersonalDataPage InputNickname(string nickname)
        {
            Waiter.WaitElementIsVisible(By.XPath(_nicknameFieldXpath));

            IWebElement webElement = Driver.FindElement(By.XPath(_nicknameFieldXpath));
            webElement.Clear();
            webElement.SendKeys(nickname);

            return this;
        }

        /// <summary>
        /// Presses the save button.
        /// </summary>
        /// <returns>Personal data page.</returns>
        public PersonalDataPage SaveChanges()
        {
            Waiter.WaitElementIsVisible(By.XPath(_saveButtonXpath));

            Driver.FindElement(By.XPath(_saveButtonXpath)).Click();

            return this;
        }

        /// <summary>
        /// Changes the old nickname to a new one.
        /// </summary>
        /// <param name="nickname">New nickname.</param>
        /// <returns>Personal data page.</returns>
        public PersonalDataPage ChangeNickname(string nickname)
        {
            InputNickname(nickname);

            return SaveChanges();
        }
    }
}

using Mail.Base;
using Mail.MailRu.Home;
using OpenQA.Selenium;

namespace Mail.MailRu.PersonalData
{
    /// <summary>
    /// Represents a page describing the personal data page.
    /// </summary>
    public class PersonalDataPage : BasePage
    {
        private readonly string _nicknameFieldXpath = "//input[@id='nickname']";
        private readonly string _nicknameAttribut = "value";
        private readonly string _saveButtonXpath = "//span[text()='Сохранить']";
        private readonly string _homePageButtonXpath = "//span[text()='Почта']/parent::a";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public PersonalDataPage(IWebDriver driver) : base(driver)
        {
            WaitPageLoading();
        }

        /// <summary>
        /// Waiting for the persanal data page to load.
        /// </summary>
        public override void WaitPageLoading()
        {
            base.WaitPageLoading();

            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementToBeClickable(By.XPath(_saveButtonXpath));
        }

        /// <summary>
        /// Returns nickname.
        /// </summary>
        /// <returns>Nickname</returns>
        public string GetNickname()
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_nicknameFieldXpath));

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
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_nicknameFieldXpath));

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
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_saveButtonXpath));

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

        /// <summary>
        /// Opens the home page.
        /// </summary>
        /// <returns>home page.</returns>
        public HomePage OpenHomePage()
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_homePageButtonXpath));

            Driver.FindElement(By.XPath(_homePageButtonXpath)).Click();

            return new HomePage(Driver);
        }
    }
}

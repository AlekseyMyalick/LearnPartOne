using OpenQA.Selenium;
using NLog;
using Mail.Base;
using Waiter;
using Mail.MailServices.MailRu.Home;
using Mail.Util;

namespace Mail.MailServices.MailRu.PersonalData
{
    /// <summary>
    /// Represents a page describing the personal data page.
    /// </summary>
    public class PersonalDataPage : BasePage
    {
        public IWebElement NicknameField => Driver.FindElement(By.XPath("//input[@id='nickname']"), WaitTime);

        public IWebElement SaveButton => Driver.FindElement(By.XPath("//span[text()='Сохранить']"), WaitTime);

        public IWebElement HomePageButton => Driver.FindElement(By.XPath("//span[text()='Почта']/parent::a"), WaitTime);

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly string _nicknameAttribut = "value";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public PersonalDataPage(IWebDriver driver) : base(driver)
        {
            base.WaitPageLoading();
        }

        /// <summary>
        /// Returns nickname.
        /// </summary>
        /// <returns>Nickname</returns>
        public string GetNickname()
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementIsVisible(NicknameField);

            return NicknameField.GetAttribute(_nicknameAttribut);
        }

        /// <summary>
        /// Introduces a new nickname.
        /// </summary>
        /// <param name="nickname">New nickname.</param>
        /// <returns>Personal data page.</returns>
        public PersonalDataPage InputNickname(string nickname)
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementIsVisible(NicknameField);

            NicknameField.Clear();
            NicknameField.SendKeys(nickname);

            return this;
        }

        /// <summary>
        /// Presses the save button.
        /// </summary>
        /// <returns>Personal data page.</returns>
        public PersonalDataPage SaveChanges()
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementToBeClickable(SaveButton);

            SaveButton.Click();

            return this;
        }

        /// <summary>
        /// Changes the old nickname to a new one.
        /// </summary>
        /// <param name="nickname">New nickname.</param>
        /// <returns>Personal data page.</returns>
        public PersonalDataPage ChangeNickname(Alias nickname)
        {
            InputNickname(nickname.Name);

            _logger.Info($"Change nickname to {nickname.Name}");

            return SaveChanges();
        }

        /// <summary>
        /// Opens the home page.
        /// </summary>
        /// <returns>home page.</returns>
        public HomePage OpenHomePage()
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementToBeClickable(HomePageButton);

            HomePageButton.Click();

            return new HomePage(Driver);
        }
    }
}

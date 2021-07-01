using OpenQA.Selenium;
using Waiters;

namespace MailRuModel.Pages
{
    /// <summary>
    /// It is a page describing the home page.
    /// </summary>
    public class HomePage : BasePage
    {
        private readonly string _writeLetterButton = "//span[text()='Написать письмо']";
        private readonly string _driverTitle = "Входящие";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public HomePage(IWebDriver driver) : base(driver)
        {
            if (!_driverTitle.Equals(driver.Title))
            {
                throw new InvalidElementStateException("This is not the login page");
            }
        }

        /// <summary>
        /// Opens the page for writing a letter.
        /// </summary>
        /// <returns>Write letter page.</returns>
        public WriteLetterPage OpenWriteLetterPage()
        {
            Waiter.WaitElementExists(By.XPath(_writeLetterButton));

            Driver.FindElement(By.XPath(_writeLetterButton)).Submit();

            return new WriteLetterPage(Driver);
        }
    }
}

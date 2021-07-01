using OpenQA.Selenium;
using Waiters;

namespace MailRuModel.Pages
{
    /// <summary>
    /// This is the page describing the page for writing a letter.
    /// </summary>
    public class WriteLetterPage : BasePage
    {
        private readonly string _driverTitle = "Входящие";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver"></param>
        public WriteLetterPage(IWebDriver driver) : base(driver)
        {
            if (!_driverTitle.Equals(driver.Title))
            {
                throw new InvalidElementStateException("This is not the login page");
            }
        }
    }
}

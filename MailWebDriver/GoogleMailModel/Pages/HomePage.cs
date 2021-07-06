using OpenQA.Selenium;
using Waiters;

namespace GoogleMailModel.Pages
{
    /// <summary>
    /// It is a page describing the home page.
    /// </summary>
    public class HomePage : BasePage
    {
        private readonly string _driverTitle = "";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public HomePage(IWebDriver driver) : base(driver)
        {
            Waiter.WaitTitleContains(_driverTitle);
        }
    }
}

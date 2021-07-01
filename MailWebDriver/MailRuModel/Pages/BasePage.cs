using OpenQA.Selenium;
using Waiters;

namespace MailRuModel.Pages
{
    /// <summary>
    /// Represents a class whose methods are common to all web pages.
    /// </summary>
    public class BasePage
    {
        /// <summary>
        /// Get or Set driver.
        /// </summary>
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// Initializes the fields of the class 
        /// and sets the time to wait for events.
        /// </summary>
        /// <param name="driver"></param>
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Waiter.Driver = Driver;
            Waiter.WaitTime = 5000;
        }
    }
}

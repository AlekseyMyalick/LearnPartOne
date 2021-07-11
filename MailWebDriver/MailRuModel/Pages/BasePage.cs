using OpenQA.Selenium;
using Waiters;

namespace MailRuModel.Pages
{
    /// <summary>
    /// Represents a class whose methods are common to all web pages.
    /// </summary>
    abstract public class BasePage
    {
        /// <summary>
        /// Get or Set driver.
        /// </summary>
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// Initializes the fields of the class.
        /// and sets the time to wait for events.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Waiter.Driver = Driver;
            Waiter.WaitTime = 20000;
        }

        /// <summary>
        /// Waiting for the page to load.
        /// </summary>
        public abstract void PageLoading();
    }
}

using OpenQA.Selenium;
using Waiters;

namespace GoogleMailModel.Pages
{
    /// <summary>
    /// Represents a class whose methods are common to all web pages.
    /// </summary>
    abstract public class BasePage
    {
        /// <summary>
        /// Wait time, measured in milliseconds.
        /// </summary>
        private readonly int _waitTime = 20000;

        /// <summary>
        /// Get or Set driver.
        /// </summary>
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// Initializes the fields of the class
        /// and sets the time to wait for events.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Waiter.Driver = Driver;
            Waiter.WaitTime = _waitTime;
        }

        /// <summary>
        /// Waiting for the page to load.
        /// </summary>
        public abstract void WaitPageLoading();
    }
}

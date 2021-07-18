using OpenQA.Selenium;

namespace Mail.Base
{
    /// <summary>
    /// Represents a class whose methods are common to all web pages.
    /// </summary>
    abstract public class BasePage
    {
        /// <summary>
        /// Get the wait time, measured in milliseconds.
        /// </summary>
        public int WaitTime => 20000;

        /// <summary>
        /// Get or Set driver.
        /// </summary>
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        /// <summary>
        /// Waiting for the page to load.
        /// </summary>
        public virtual void WaitPageLoading()
        {
            new Waiter.Waiter(Driver, WaitTime).WaitPageLoading();
        }
    }
}

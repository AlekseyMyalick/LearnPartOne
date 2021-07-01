using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Waiters
{
    /// <summary>
    /// Represents a class whose methods implement 
    /// explicitly waiting for web element events.
    /// </summary>
    public static class Waiter
    {
        /// <summary>
        /// Get or Set driver.
        /// </summary>
        public static IWebDriver Driver { get; set; }

        /// <summary>
        /// Get or Set waiting time.
        /// </summary>
        public static int WaitTime { get; set; }

        /// <summary>
        /// Waits for the element to appear.
        /// </summary>
        /// <param name="webElementLocator">Web element locator.</param>
        public static void WaitElementExists(By webElementLocator)
        {
            new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime)).
                Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(webElementLocator));
        }
    }
}

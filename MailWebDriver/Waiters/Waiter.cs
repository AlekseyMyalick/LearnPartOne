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
        public static void WaitElementIsVisible(By webElementLocator)
        {
            new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime)).
                Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(webElementLocator));
        }

        /// <summary>
        /// An expectation for checking the title of a page.
        /// </summary>
        /// <param name="title">Title.</param>
        public static void WaitTitleContains(string title)
        {
            new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime)).
                Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains(title));
        }

        /// <summary>
        /// Waits for an element to become clickable.
        /// </summary>
        /// <param name="webElementLocator">Web element locator.</param>
        public static void WaitElementToBeClickable(By webElementLocator)
        {
            new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime)).
                Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElementLocator));
        }
    }
}

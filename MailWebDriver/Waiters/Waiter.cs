using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
                Until(ExpectedConditions.ElementIsVisible(webElementLocator));
        }

        /// <summary>
        /// An expectation for checking the title of a page.
        /// </summary>
        /// <param name="title">Title.</param>
        public static void WaitTitleContains(string title)
        {
            new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime)).
                Until(ExpectedConditions.TitleContains(title));
        }

        /// <summary>
        /// Waits for an element to become clickable.
        /// </summary>
        /// <param name="webElementLocator">Web element locator.</param>
        public static void WaitElementToBeClickable(By webElementLocator)
        {
            new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime)).
                Until(ExpectedConditions.ElementToBeClickable(webElementLocator));
        }

        /// <summary>
        /// Waiting for full page load.
        /// </summary>
        public static void WaitPageLoading()
        {
            new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime)).
                Until(IsPageLoading);
        }

        /// <summary>
        /// Returns the state of the page.
        /// </summary>
        /// <param name="driver">Web driver.</param>
        /// <returns>True if the page is loaded, otherwise false.</returns>
        private static bool IsPageLoading(IWebDriver driver)
        {
            return (driver as IJavaScriptExecutor)
                .ExecuteScript("return document.readyState").Equals("complete");
        }
    }
}

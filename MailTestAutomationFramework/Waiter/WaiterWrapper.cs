using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Waiter
{
    /// <summary>
    /// Represents a class whose methods implement
    /// explicitly waiting for web element events.
    /// </summary>
    public class WaiterWrapper
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
        /// Initialization of the fields of the class object.
        /// </summary>
        /// <param name="driver">Web driver;</param>
        /// <param name="waitTime">Wait time,
        /// measured in milliseconds</param>
        public WaiterWrapper(IWebDriver driver, int waitTime)
        {
            Driver = driver;
            WaitTime = waitTime;
        }

        /// <summary>
        /// Waits for the element to appear.
        /// </summary>
        /// <param name="webElementLocator">Web element locator.</param>
        public IWebElement WaitElementIsVisible(By webElementLocator)
        {
            return new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementIsVisible(webElementLocator));
        }

        /// <summary>
        /// Waits for the element to appear.
        /// </summary>
        /// <param name="webElement">Web element.</param>
        public IWebElement WaitElementIsVisible(IWebElement webElement)
        {
            return new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime))
                .Until(ExpectedConditionsWrapper.ElementIsVisible(webElement));
        }

        /// <summary>
        /// Waits for an element to become clickable.
        /// </summary>
        /// <param name="webElementLocator">Web element locator.</param>
        public IWebElement WaitElementToBeClickable(By webElementLocator)
        {
            return new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementToBeClickable(webElementLocator));
        }

        /// <summary>
        /// Waits for an element to become clickable.
        /// </summary>
        /// <param name="webElement">Web element.</param>
        public IWebElement WaitElementToBeClickable(IWebElement webElement)
        {
            return new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime))
                .Until(ExpectedConditionsWrapper.ElementToBeClickable(webElement));
        }

        /// <summary>
        /// Waits for a substring to appear in the title.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <returns>true when the title matches, otherwise, false.</returns>
        public bool WaitTitleContains(string title)
        {
            return new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .TitleContains(title));
        }

        /// <summary>
        /// Waiting for full page load.
        /// </summary>
        public void WaitPageLoading()
        {
            new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime))
                .Until(IsPageLoading);
        }

        /// <summary>
        /// Waiting for a check that the element with the text
        /// is either invisible or not present in the DOM.
        /// </summary>
        /// <param name="webElementLocator">Web element locator.</param>
        public void WaitVisibilityOfAllElementsLocatedBy(By webElementLocator)
        {
            new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .VisibilityOfAllElementsLocatedBy(webElementLocator));
        }

        /// <summary>
        /// An expectation for checking that an element with text
        /// is either invisible or not present on the DOM.
        /// </summary>
        /// <param name="webElementLocator">Web element locator.</param>
        /// <param name="text">WebElement text.</param>
        public bool WaitInvisibilityOfElementWithText(By webElementLocator, string text)
        {
            return new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .InvisibilityOfElementWithText(webElementLocator, text));
        }

        /// <summary>
        /// An expectation for checking that an element with text
        /// is either invisible or not present on the DOM.
        /// </summary>
        /// <param name="webElementLocator">Web element locator.</param>
        /// <param name="text">WebElement text.</param>
        public bool WaitInvisibilityOfElementWithText(IWebElement webElement, string text)
        {
            return new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime))
                .Until(ExpectedConditionsWrapper.InvisibilityOfElementWithText(webElement, text));
        }

        /// <summary>
        /// Returns the state of the page.
        /// </summary>
        /// <param name="driver">Web driver.</param>
        /// <returns>True if the page is loaded, otherwise false.</returns>
        private bool IsPageLoading(IWebDriver driver)
        {
            return (driver as IJavaScriptExecutor)
                .ExecuteScript("return document.readyState").Equals("complete");
        }
    }
}
using OpenQA.Selenium;
using Waiter;

namespace Mail.Util
{
    public static class Halper
    {
        /// <summary>
        /// The extension method finds the web element
        /// while waiting for it to appear in the DOM.
        /// </summary>
        /// <param name="driver">Driver.</param>
        /// <param name="by">Element locator.</param>
        /// <param name="waitTime">Waiting time.</param>
        /// <returns></returns>
        public static IWebElement FindElement(this IWebDriver driver, By by, int waitTime)
        {
            return new WaiterWrapper(driver, waitTime).WaitElementIsVisible(by);
        }
    }
}

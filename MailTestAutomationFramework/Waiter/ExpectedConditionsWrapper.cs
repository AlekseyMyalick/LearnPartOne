using System;
using OpenQA.Selenium;

namespace Waiter
{
    /// <summary>
    /// Supplies a set of common conditions that can be waited for using WebDriverWait.
    /// </summary>
    public static class ExpectedConditionsWrapper
    {
        /// <summary>
        /// An expectation for checking that an element
        /// is present on the DOM of a page and visible.
        /// </summary>
        /// <param name="webElement">Web element.</param>
        /// <returns>Web element.</returns>
        public static Func<IWebDriver, IWebElement> ElementIsVisible(IWebElement webElement)
        {
            return driver =>
            {
                try
                {
                    return ElementIsDisplayed(webElement);
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        /// <summary>
        /// An expectation for checking an element
        /// is visible and enabled such that you can click it.
        /// </summary>
        /// <param name="webElement">Web element.</param>
        /// <returns>Web element.</returns>
        public static Func<IWebDriver, IWebElement> ElementToBeClickable(IWebElement webElement)
        {
            return driver =>
            {
                try
                {
                    if (webElement != null && webElement.Enabled)
                    {
                        return webElement;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        /// <summary>
        /// An expectation for checking that an element
        /// with text is either invisible or not present on the DOM.
        /// </summary>
        /// <param name="webElement">Web element.</param>
        /// <param name="text">Web element text.</param>
        /// <returns>Web element.</returns>
        public static Func<IWebDriver, bool> InvisibilityOfElementWithText(IWebElement webElement, string text)
        {
            return driver =>
            {
                try
                {
                    string webElementText = webElement.Text;

                    if (string.IsNullOrEmpty(webElementText))
                    {
                        return true;
                    }

                    return !webElementText.Equals(text);
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            };
        }

        private static IWebElement ElementIsDisplayed(IWebElement webElement)
        {
            return webElement.Displayed ? webElement : null;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Waiters;


namespace GoogleMailModel.Pages
{
    public class InboxPage : BasePage
    {
        private readonly string _lettersXpath = "//div[@class='Cp']/parent::div/child::div[last()]//tbody/child::tr";
        private readonly string _lastIncomingLetter = "//div[@class='Cp']/parent::div/child::div[last()]//tbody/child::tr[1]";
        private readonly string _driverTitle = "Входящие";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public InboxPage(IWebDriver driver) : base(driver)
        {
            PageLoading();
        }

        /// <summary>
        /// Waiting for the home page to load.
        /// </summary>
        public override void PageLoading()
        {
            Waiter.WaitTitleContains(_driverTitle);
        }

        /// <summary>
        /// Opens the last email that arrived.
        /// </summary>
        /// <returns>Incoming letter page.</returns>
        public IncomingLetterPage OpenLastIncomingLetter()
        {
            Waiter.WaitElementIsVisible(By.XPath(_lastIncomingLetter));

            Driver.FindElement(By.XPath(_lastIncomingLetter)).Click();

            return new IncomingLetterPage(Driver);
        }
    }
}

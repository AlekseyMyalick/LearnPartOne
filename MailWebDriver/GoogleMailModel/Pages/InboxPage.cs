using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Waiters;


namespace GoogleMailModel.Pages
{
    public class InboxPage : BasePage
    {
        private readonly string _lettersXpath = "//table[@id=':23']//tbody/child::tr";
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
        /// Returns a collection of all incoming emails.
        /// </summary>
        /// <returns>The IWebElement collection.</returns>
        public List<IWebElement> GetLetters()
        {
            Waiter.WaitElementIsVisible(By.XPath(_lettersXpath));

            return Driver.FindElements(By.XPath(_lettersXpath)).ToList();
        }
    }
}

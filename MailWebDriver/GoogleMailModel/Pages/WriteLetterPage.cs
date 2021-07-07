using OpenQA.Selenium;
using Waiters;

namespace GoogleMailModel.Pages
{
    class WriteLetterPage : BasePage
    {
        private readonly string _writeLetterWindowXpath = "";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver"></param>
        public WriteLetterPage(IWebDriver driver) : base(driver)
        {
            PageLoading();
        }

        /// <summary>
        /// Waiting for the write letter page to load.
        /// </summary>
        public override void PageLoading()
        {
            Waiter.WaitElementIsVisible(By.XPath(_writeLetterWindowXpath));
        }
    }
}

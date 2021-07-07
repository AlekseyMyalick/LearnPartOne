using OpenQA.Selenium;
using Waiters;

namespace GoogleMailModel.Pages
{
    class IncomingLetterPage : BasePage
    {
        private readonly string _replyButton = "//span[text()='Ответить']";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public IncomingLetterPage(IWebDriver driver) : base(driver)
        {
            PageLoading();
        }

        /// <summary>
        /// Waiting for the incoming letter page to load.
        /// </summary>
        public override void PageLoading()
        {
            Waiter.WaitTitleContains(_replyButton);
        }
    }
}

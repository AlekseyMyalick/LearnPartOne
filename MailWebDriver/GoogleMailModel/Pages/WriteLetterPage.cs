using OpenQA.Selenium;
using Waiters;

namespace GoogleMailModel.Pages
{
    class WriteLetterPage : BasePage
    {
        private readonly string _writeLetterWindowXpath = "//div[@class='AD']";
        private readonly string _receiverXpath = "//span[text()='Кому']/ancestor::div[@class='fX aiL']//textarea";


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

        /// <summary>
        /// Enters receiver.
        /// </summary>
        /// <param name="receiver">Receiver.</param>
        /// <returns>The same page with the entered receiver.</returns>
        public WriteLetterPage TypeReceiver(string receiver)
        {
            Waiter.WaitElementIsVisible(By.XPath(_receiverXpath));

            Driver.FindElement(By.XPath(_receiverXpath)).SendKeys(receiver);

            return this;
        }
    }
}

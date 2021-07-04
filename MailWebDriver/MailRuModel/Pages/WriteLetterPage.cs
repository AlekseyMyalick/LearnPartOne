using OpenQA.Selenium;
using System.Threading;
using Waiters;

namespace MailRuModel.Pages
{
    /// <summary>
    /// This is the page describing the page for writing a letter.
    /// </summary>
    public class WriteLetterPage : BasePage
    {
        private readonly string _writeLetterWindowXpath = "//div[contains(@class, 'compose-windows')]";
        private readonly string _receiverXpath = "//div[text()='Кому']/ancestor::div[contains(@class, 'head_container')]//input";
        private readonly string _letterXpath = "//br/parent::div";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver"></param>
        public WriteLetterPage(IWebDriver driver) : base(driver)
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

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
        private readonly string _sendLetterButton = "//span[text()='Отправить']";
        private readonly string _letterXpath = "//br/parent::div";
        private readonly string _layerWindowXpath = "//div[contains(@class, 'layer-window__container')]";
        private readonly string _closeLayerWindowButtonXpath = "//div[@class='layer__controls']/span";

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

        /// <summary>
        /// Enters the text of the letter.
        /// </summary>
        /// <param name="letterText">Text of the letter</param>
        /// <returns>The same page with the entered text of the letter.</returns>
        public WriteLetterPage TypeLetter(string letterText)
        {
            Waiter.WaitElementIsVisible(By.XPath(_letterXpath));

            Driver.FindElement(By.XPath(_letterXpath)).SendKeys(letterText);

            return this;
        }

        /// <summary>
        /// Presses the send letter button.
        /// </summary>
        /// <returns>The same page with a layered window.</returns>
        public WriteLetterPage SubmitLetter()
        {
            Waiter.WaitElementIsVisible(By.XPath(_sendLetterButton));

            Driver.FindElement(By.XPath(_sendLetterButton)).Click();

            return this;
        }

        /// <summary>
        /// Presses the close layer window button.
        /// </summary>
        /// <returns>Home page.</returns>
        public HomePage CloseLayerWindow()
        {
            Waiter.WaitElementIsVisible(By.XPath(_layerWindowXpath));
            Waiter.WaitElementIsVisible(By.XPath(_closeLayerWindowButtonXpath));

            Driver.FindElement(By.XPath(_closeLayerWindowButtonXpath)).Click();

            return new HomePage(Driver);
        }

        /// <summary>
        /// Sends a letter to the specified sender with the specified content.
        /// </summary>
        /// <param name="receiver">Receiver.</param>
        /// <param name="letterText">Text of the letter.</param>
        /// <returns>Home page.</returns>
        public HomePage WriteLetter(string receiver, string letterText)
        {
            TypeReceiver(receiver);
            TypeLetter(letterText);
            SubmitLetter();

            return CloseLayerWindow();
        }
    }
}

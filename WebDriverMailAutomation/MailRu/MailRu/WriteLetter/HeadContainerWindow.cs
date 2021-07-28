using Mail.Base;
using Mail.MailRu.Home;
using OpenQA.Selenium;

namespace Mail.MailRu.WriteLetter
{
    /// <summary>
    /// Represents a class that describes a title container window.
    /// </summary>
    public class HeadContainerWindow : BasePage
    {
        public IWebElement Receiver => Driver.FindElement(By.XPath("//div[text()='Кому']/ancestor::div[contains(@class, 'head_container')]//input"));

        private readonly string _closeLayerWindowButtonXpath = "//div[@class='layer__controls']/span";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public HeadContainerWindow(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Enters receiver.
        /// </summary>
        /// <param name="receiver">Receiver.</param>
        /// <returns>Head container window.</returns>
        public HeadContainerWindow TypeReceiver(string receiver)
        {
            Receiver.SendKeys(receiver);

            return this;
        }

        /// <summary>
        /// Presses the close layer window button.
        /// </summary>
        /// <returns>Home page.</returns>
        public HomePage CloseLayerWindow()
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementToBeClickable(By.XPath(_closeLayerWindowButtonXpath));

            Driver.FindElement(By.XPath(_closeLayerWindowButtonXpath)).Click();

            return new HomePage(Driver);
        }
    }
}

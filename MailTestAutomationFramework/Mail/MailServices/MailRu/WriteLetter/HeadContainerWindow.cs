using OpenQA.Selenium;
using Mail.Base;
using Waiter;
using Mail.Util;
using Mail.MailServices.MailRu.Home;

namespace Mail.MailServices.MailRu.WriteLetter
{
    /// <summary>
    /// Represents a class that describes a title container window.
    /// </summary>
    public class HeadContainerWindow : BasePage
    {
        public IWebElement Receiver =>
            Driver.FindElement(By.XPath("//div[text()='Кому']/ancestor::div[contains(@class, 'head_container')]//input"), WaitTime);

        public IWebElement CloseLayerWindowButton => Driver.FindElement(By.XPath("//div[@class='layer__controls']/span"), WaitTime);

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public HeadContainerWindow(IWebDriver driver) : base(driver)
        {
            base.WaitPageLoading();
        }

        /// <summary>
        /// Enters receiver.
        /// </summary>
        /// <param name="receiver">Receiver.</param>
        /// <returns>Head container window.</returns>
        public HeadContainerWindow TypeReceiver(string receiver)
        {
            new WaiterWrapper(Driver, WaitTime).WaitElementIsVisible(Receiver);

            Receiver.SendKeys(receiver);

            return this;
        }

        /// <summary>
        /// Presses the close layer window button.
        /// </summary>
        /// <returns>Home page.</returns>
        public HomePage CloseLayerWindow()
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementIsVisible(CloseLayerWindowButton);

            CloseLayerWindowButton.Click();

            return new HomePage(Driver);
        }
    }
}

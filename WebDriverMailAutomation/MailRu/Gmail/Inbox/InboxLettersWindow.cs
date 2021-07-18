using OpenQA.Selenium;
using Mail.Base;

namespace Mail.Gmail.Inbox
{
    /// <summary>
    /// Represents a class that describes a letter inbox window.
    /// </summary>
    class InboxLettersWindow : BasePage
    {
        private readonly string _lastIncomingLetterXpath = "//div[@class='Cp']/parent::div/child::div[last()]//tbody/child::tr[1]";
        private readonly string _allLettersXpath = "//div[@class='Cp']/parent::div/child::div[last()]//tbody/child::tr";
        private readonly string _fontWeightCssPropertyNameXpath = "font-weight";
        private readonly string _lastLetterSenderEmailXpath = "//span[@email]";
        private readonly string _lastLetterSenderNameXpath = "//span[@name]";
        private readonly string _senderEmailAttribute = "email";
        private readonly int _boldFontWeight = 700;

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public InboxLettersWindow(IWebDriver driver) : base(driver)
        {
            WaitPageLoading();
        }

        /// <summary>
        /// Waiting for the home page to load.
        /// </summary>
        public override void WaitPageLoading()
        {
            base.WaitPageLoading();

            new Waiter.Waiter(Driver, WaitTime)
                .WaitVisibilityOfAllElementsLocatedBy(By.XPath(_allLettersXpath));
        }

        /// <summary>
        /// Checks if the last received message has been read.
        /// </summary>
        /// <returns>True, if the letter is not read, otherwise false.</returns>
        public bool IsNotReadedLastIncomingLetter()
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_lastIncomingLetterXpath));

            string fontWeight = Driver.FindElement(By
                .XPath(_lastIncomingLetterXpath + _lastLetterSenderNameXpath))
                .GetCssValue(_fontWeightCssPropertyNameXpath);

            return int.Parse(fontWeight) == _boldFontWeight;
        }

        /// <summary>
        /// Opens the last letter that arrived.
        /// </summary>
        /// <returns>Letter window.</returns>
        public LetterWindow OpenLastIncomingLetter()
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_lastIncomingLetterXpath));

            Driver.FindElement(By.XPath(_lastIncomingLetterXpath)).Click();

            return new LetterWindow(Driver);
        }

        /// <summary>
        /// Returns the email of the sender.
        /// </summary>
        /// <returns>Email.</returns>
        public string GetSenderEmail()
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_lastIncomingLetterXpath));

            string actualSender = Driver.FindElement(By
                .XPath(_lastIncomingLetterXpath + _lastLetterSenderEmailXpath))
                .GetAttribute(_senderEmailAttribute);

            return actualSender;
        }
    }
}

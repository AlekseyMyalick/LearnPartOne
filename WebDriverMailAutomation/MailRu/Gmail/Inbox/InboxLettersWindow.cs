using OpenQA.Selenium;
using NLog;
using Mail.Base;

namespace Mail.Gmail.Inbox
{
    /// <summary>
    /// Represents a class that describes a letter inbox window.
    /// </summary>
    class InboxLettersWindow : BasePage
    {
        public IWebElement LastLetterSenderEmail =>
            Driver.FindElement(By.XPath("//div[@class='Cp']/parent::div/child::div[last()]//tbody/child::tr[1]//span[@email]"));

        public IWebElement LastLetterSenderName =>
            Driver.FindElement(By.XPath("//div[@class='Cp']/parent::div/child::div[last()]//tbody/child::tr[1]//span[@name]"));

        public IWebElement LastIncomingLetter =>
            Driver.FindElement(By.XPath("//div[@class='Cp']/parent::div/child::div[last()]//tbody/child::tr[1]"));

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly string _allLettersXpath = "//div[@class='Cp']/parent::div/child::div[last()]//tbody/child::tr";
        private readonly string _fontWeightCssPropertyName = "font-weight";
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
            string fontWeight = LastLetterSenderName
                .GetCssValue(_fontWeightCssPropertyName);

            return int.Parse(fontWeight) == _boldFontWeight;
        }

        /// <summary>
        /// Opens the last letter that arrived.
        /// </summary>
        /// <returns>Letter window.</returns>
        public LetterWindow OpenLastIncomingLetter()
        {
            LastIncomingLetter.Click();

            _logger.Info("The last incoming letter is open.");

            return new LetterWindow(Driver);
        }

        /// <summary>
        /// Returns the email of the sender.
        /// </summary>
        /// <returns>Email.</returns>
        public string GetSenderEmail()
        {
            string actualSender = LastLetterSenderEmail
                .GetAttribute(_senderEmailAttribute);

            return actualSender;
        }
    }
}

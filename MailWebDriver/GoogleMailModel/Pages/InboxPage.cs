using OpenQA.Selenium;
using Waiters;


namespace GoogleMailModel.Pages
{
    public class InboxPage : BasePage
    {
        private readonly string _lastIncomingLetter = "//div[@class='Cp']/parent::div/child::div[last()]//tbody/child::tr[1]";
        private readonly string _showHiddenPartButton = "//div[@data-tooltip='Показать скрытую часть']";
        private readonly string _replyButton = "//span[@role='link'][text()='Ответить']";
        private readonly string _lastLetterSenderName = "//span[@name]";
        private readonly string _lastLetterSenderEmail = "//span[@email]";
        private readonly string _fontWeightCssPropertyName = "font-weight";
        private readonly int _boldFontWeight = 700;
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
        /// Checks if the last received message has been read.
        /// </summary>
        /// <returns>True, if the letter is not read, otherwise false.</returns>
        public bool IsNotReadedLastIncomingLetter()
        {
            Waiter.WaitElementIsVisible(By.XPath(_lastIncomingLetter));

            string fontWeight = Driver.FindElement(By
                .XPath(_lastIncomingLetter + _lastLetterSenderName))
                .GetCssValue(_fontWeightCssPropertyName);

            return int.Parse(fontWeight) == _boldFontWeight;
        }

        /// <summary>
        /// Opens the last letter that arrived.
        /// </summary>
        /// <returns>Inbox page.</returns>
        public InboxPage OpenLastIncomingLetter()
        {
            Waiter.WaitElementIsVisible(By.XPath(_lastIncomingLetter));

            Driver.FindElement(By.XPath(_lastIncomingLetter)).Click();

            return this;
        }

        /// <summary>
        /// Checks if the current sender matches the expected one.
        /// </summary>
        /// <param name="expectedSender">Expected sender.</param>
        /// <returns>True, if the expected sender matches the current one,
        /// otherwise it is false.</returns>
        public bool IsExpectedSender(string expectedSender)
        {
            Waiter.WaitElementIsVisible(By.XPath(_lastIncomingLetter));

            string actualSender = Driver.FindElement(By
                .XPath(_lastIncomingLetter + _lastLetterSenderEmail))
                .Text;

            return expectedSender == actualSender;
        }

        /// <summary>
        /// Opens a page for responding to a letter.
        /// </summary>
        /// <returns>Inbox page.</returns>
        public InboxPage OpenReplyWindow()
        {
            Waiter.WaitElementIsVisible(By.XPath(_replyButton));

            Driver.FindElement(By.XPath(_replyButton)).Click();

            return this;
        }

        /// <summary>
        /// Opens a hidden part of the message reply window.
        /// </summary>
        /// <returns>Inbox page.</returns>
        public InboxPage OpenHiddenPartReplyWindow()
        {
            Waiter.WaitElementIsVisible(By.XPath(_showHiddenPartButton));

            Driver.FindElement(By.XPath(_showHiddenPartButton)).Click();

            return this;
        }
    }
}

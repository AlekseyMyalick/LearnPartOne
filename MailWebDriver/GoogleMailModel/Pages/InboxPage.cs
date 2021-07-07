using OpenQA.Selenium;
using Waiters;


namespace GoogleMailModel.Pages
{
    public class InboxPage : BasePage
    {
        private readonly string _lastIncomingLetterXpath = "//div[@class='Cp']/parent::div/child::div[last()]//tbody/child::tr[1]";
        private readonly string _showHiddenPartButtonXpath = "//div[@data-tooltip='Показать скрытую часть']";
        private readonly string _replyLetterBoxXpath = "//div[@aria-label='Тело письма']/div/br";
        private readonly string _replyButtonXpath = "//span[@role='link'][text()='Ответить']";
        private readonly string _lastLetterSenderNameXpath = "//span[@name]";
        private readonly string _lastLetterSenderEmailXpath = "//span[@email]";
        private readonly string _fontWeightCssPropertyNameXpath = "font-weight";
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
            Waiter.WaitElementIsVisible(By.XPath(_lastIncomingLetterXpath));

            string fontWeight = Driver.FindElement(By
                .XPath(_lastIncomingLetterXpath + _lastLetterSenderNameXpath))
                .GetCssValue(_fontWeightCssPropertyNameXpath);

            return int.Parse(fontWeight) == _boldFontWeight;
        }

        /// <summary>
        /// Opens the last letter that arrived.
        /// </summary>
        /// <returns>Inbox page.</returns>
        public InboxPage OpenLastIncomingLetter()
        {
            Waiter.WaitElementIsVisible(By.XPath(_lastIncomingLetterXpath));

            Driver.FindElement(By.XPath(_lastIncomingLetterXpath)).Click();

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
            Waiter.WaitElementIsVisible(By.XPath(_lastIncomingLetterXpath));

            string actualSender = Driver.FindElement(By
                .XPath(_lastIncomingLetterXpath + _lastLetterSenderEmailXpath))
                .Text;

            return expectedSender == actualSender;
        }

        /// <summary>
        /// Opens a page for responding to a letter.
        /// </summary>
        /// <returns>Inbox page.</returns>
        public InboxPage OpenReplyWindow()
        {
            Waiter.WaitElementIsVisible(By.XPath(_replyButtonXpath));

            Driver.FindElement(By.XPath(_replyButtonXpath)).Click();

            return this;
        }

        /// <summary>
        /// Opens a hidden part of the message reply window.
        /// </summary>
        /// <returns>Inbox page.</returns>
        public InboxPage OpenHiddenPartReplyWindow()
        {
            Waiter.WaitElementIsVisible(By.XPath(_showHiddenPartButtonXpath));

            Driver.FindElement(By.XPath(_showHiddenPartButtonXpath)).Click();

            return this;
        }

        /// <summary>
        /// Enters a reply to the letter.
        /// </summary>
        /// <param name="responseText">Text to reply to a letter.</param>
        /// <returns>Inbox page.</returns>
        public InboxPage EnterReply(string responseText)
        {
            Waiter.WaitElementIsVisible(By.XPath(_replyLetterBoxXpath));

            Driver.FindElement(By.XPath(_replyLetterBoxXpath)).SendKeys(responseText);

            return this;
        }

    }
}

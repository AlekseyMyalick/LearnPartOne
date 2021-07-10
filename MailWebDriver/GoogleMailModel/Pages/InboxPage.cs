using OpenQA.Selenium;
using Waiters;


namespace GoogleMailModel.Pages
{
    public class InboxPage : BasePage
    {
        private readonly string _lastIncomingLetterXpath = "//div[@class='Cp']/parent::div/child::div[last()]//tbody/child::tr[1]";
        private readonly string _letterTextXpath = "//div[@class='gs']//div[@id=':bf']/div[2]/div[1]";
        private readonly string _showHiddenPartButtonXpath = "//div[@data-tooltip='Показать скрытую часть']";
        private readonly string _replyLetterBoxXpath = "//div[@aria-label='Тело письма']/div[2]";
        private readonly string _senderAliasXpath = "//blockquote//br/parent::div";
        private readonly string _sendReplyButton = "//div[text()='Отправить']";
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
                .GetAttribute("email");

            return actualSender == expectedSender;
        }

        /// <summary>
        /// Compares the text of the received email with the expected one.
        /// </summary>
        /// <param name="expectedLetterText">Expected letter text.</param>
        /// <returns>True, if the text matches, otherwise it is false.</returns>
        public bool IsExpectedLetterText(string expectedLetterText)
        {
            Waiter.WaitElementIsVisible(By.XPath(_letterTextXpath));

            string actualLetterText = Driver.FindElement(By
                .XPath(_letterTextXpath))
                .Text;

            return actualLetterText == expectedLetterText;
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

        /// <summary>
        /// Changes the old alias to the new one.
        /// </summary>
        /// <param name="newAlias"></param>
        /// <returns>inbox page.</returns>
        public InboxPage ChangeAlias(string newAlias)
        {
            Waiter.WaitElementIsVisible(By.XPath(_senderAliasXpath));

            RemoveOldAlias(_senderAliasXpath);

            Driver.FindElement(By.XPath(_senderAliasXpath)).SendKeys(newAlias);

            return this;
        }

        /// <summary>
        /// Removes the old alias.
        /// </summary>
        /// <param name="senderAliasXpath">The path to the old alias.</param>
        /// <returns>Inbox page.</returns>
        private InboxPage RemoveOldAlias(string senderAliasXpath)
        {
            IWebElement element = Driver.FindElement(By.XPath(senderAliasXpath));
            element.Click();

            string aliae = element.Text;

            for (int i = 0; i < aliae.Length - 4; i++)
            {
                element.SendKeys(Keys.Backspace);
            }

            return this;
        }

        /// <summary>
        /// Presses the button to send a response.
        /// </summary>
        /// <returns>Inbox page.</returns>
        public InboxPage SendReply()
        {
            Waiter.WaitElementIsVisible(By.XPath(_sendReplyButton));

            Driver.FindElement(By.XPath(_sendReplyButton)).Click();

            return this;
        }

        /// <summary>
        /// Replies to the last received message.
        /// </summary>
        /// <param name="responseText">Text to reply to a letter.</param>
        /// <param name="newAlias">The new sender's alias.</param>
        public InboxPage ReplyToLastLetter(string responseText, string newAlias)
        {
            OpenLastIncomingLetter();
            OpenReplyWindow();
            OpenHiddenPartReplyWindow();
            EnterReply(responseText);
            ChangeAlias(newAlias);

            return SendReply();
        }
    }
}

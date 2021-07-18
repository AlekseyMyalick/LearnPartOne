using OpenQA.Selenium;
using Mail.Base;

namespace Mail.Gmail.Inbox
{
    /// <summary>
    /// Represents the class that describes the reply window.
    /// </summary>
    public class ReplyWindow : BasePage
    {
        private readonly string _showHiddenPartButtonXpath = "//div[@data-tooltip='Показать скрытую часть']";
        private readonly string _replyLetterBoxXpath = "//div[@aria-label='Тело письма']/div[2]";
        private readonly string _senderAliasXpath = "//blockquote//br/parent::div";
        private readonly string _sendReplyButton = "//div[text()='Отправить']";
        private readonly string _popupEmailSent = "//span[text()='Письмо отправлено.']";
        private readonly int _separatingCharactersNumber = 4;

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public ReplyWindow(IWebDriver driver) : base(driver)
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
                .WaitElementIsVisible(By.XPath(_sendReplyButton));
        }

        /// <summary>
        /// Opens a hidden part of the message reply window.
        /// </summary>
        /// <returns>Reply window.</returns>
        public ReplyWindow OpenHiddenPartReplyWindow()
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_showHiddenPartButtonXpath));

            Driver.FindElement(By.XPath(_showHiddenPartButtonXpath)).Click();

            return this;
        }

        /// <summary>
        /// Enters a reply to the letter.
        /// </summary>
        /// <param name="responseText">Text to reply to a letter.</param>
        /// <returns>Reply window.</returns>
        public ReplyWindow EnterReply(string responseText)
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_replyLetterBoxXpath));

            Driver.FindElement(By.XPath(_replyLetterBoxXpath)).SendKeys(responseText);

            return this;
        }

        /// <summary>
        /// Changes the old alias to the new one.
        /// </summary>
        /// <param name="newAlias"></param>
        /// <returns>Reply window.</returns>
        public ReplyWindow ChangeAlias(string newAlias)
        {
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_senderAliasXpath));

            RemoveOldAlias(_senderAliasXpath);

            Driver.FindElement(By.XPath(_senderAliasXpath)).SendKeys(newAlias);

            return this;
        }

        /// <summary>
        /// Removes the old alias.
        /// </summary>
        /// <param name="senderAliasXpath">The path to the old alias.</param>
        /// <returns>Reply window.</returns>
        private ReplyWindow RemoveOldAlias(string senderAliasXpath)
        {
            IWebElement element = Driver.FindElement(By.XPath(senderAliasXpath));
            element.Click();

            string aliae = element.Text;

            for (int i = 0; i < aliae.Length - _separatingCharactersNumber; i++)
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
            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_sendReplyButton));

            Driver.FindElement(By.XPath(_sendReplyButton)).Click();

            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_popupEmailSent));

            return new InboxPage(Driver);
        }
    }
}

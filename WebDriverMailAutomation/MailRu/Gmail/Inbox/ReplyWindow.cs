using OpenQA.Selenium;
using Mail.Base;

namespace Mail.Gmail.Inbox
{
    /// <summary>
    /// Represents the class that describes the reply window.
    /// </summary>
    public class ReplyWindow : BasePage
    {
        public IWebElement ShowHiddenPartButton => Driver.FindElement(By.XPath("//div[@data-tooltip='Показать скрытую часть']"));

        public IWebElement ReplyLetterBox => Driver.FindElement(By.XPath("//div[@aria-label='Тело письма']/div[2]"));

        public IWebElement SenderAlias => Driver.FindElement(By.XPath("//blockquote//br/parent::div"));

        public IWebElement SendReplyButton => Driver.FindElement(By.XPath("//div[text()='Отправить']"));

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
            ShowHiddenPartButton.Click();

            return this;
        }

        /// <summary>
        /// Enters a reply to the letter.
        /// </summary>
        /// <param name="responseText">Text to reply to a letter.</param>
        /// <returns>Reply window.</returns>
        public ReplyWindow EnterReply(string responseText)
        {
            ReplyLetterBox.SendKeys(responseText);

            return this;
        }

        /// <summary>
        /// Changes the old alias to the new one.
        /// </summary>
        /// <param name="newAlias"></param>
        /// <returns>Reply window.</returns>
        public ReplyWindow ChangeAlias(Alias newAlias)
        {
            RemoveOldAlias(SenderAlias);
            SenderAlias.SendKeys(newAlias.Name);

            return this;
        }

        /// <summary>
        /// Removes the old alias.
        /// </summary>
        /// <param name="senderAliasXpath">The path to the old alias.</param>
        /// <returns>Reply window.</returns>
        private ReplyWindow RemoveOldAlias(IWebElement element)
        {
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
            SendReplyButton.Click();

            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_popupEmailSent));

            return new InboxPage(Driver);
        }
    }
}

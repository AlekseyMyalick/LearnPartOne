using Mail.Base;
using Mail.Util;
using Waiter;
using OpenQA.Selenium;

namespace Mail.MailServices.Gmail.Inbox
{
    /// <summary>
    /// Represents the class that describes the reply window.
    /// </summary>
    public class ReplyWindow : BasePage
    {
        public IWebElement ShowHiddenPartButton => Driver.FindElement(By.XPath("//div[@data-tooltip='Показать скрытую часть']"), WaitTime);

        public IWebElement ReplyLetterBox => Driver.FindElement(By.XPath("//div[@aria-label='Тело письма']/div[2]"), WaitTime);

        public IWebElement SenderAlias => Driver.FindElement(By.XPath("//blockquote//br/parent::div"), WaitTime);

        public IWebElement SendReplyButton => Driver.FindElement(By.XPath("//div[text()='Отправить']"), WaitTime);

        public IWebElement PopupEmailSent => Driver.FindElement(By.XPath("//span[text()='Письмо отправлено.']"), WaitTime);

        private readonly int _separatingCharactersNumber = 4;

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public ReplyWindow(IWebDriver driver) : base(driver)
        {
            base.WaitPageLoading();
        }

        /// <summary>
        /// Opens a hidden part of the message reply window.
        /// </summary>
        /// <returns>Reply window.</returns>
        public ReplyWindow OpenHiddenPartReplyWindow()
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementToBeClickable(ShowHiddenPartButton);

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

            string alias = element.Text;

            for (int i = 0; i < alias.Length - _separatingCharactersNumber; i++)
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
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementToBeClickable(SendReplyButton);

            SendReplyButton.Click();

            new WaiterWrapper(Driver, WaitTime)
                .WaitElementIsVisible(PopupEmailSent);

            return new InboxPage(Driver);
        }
    }
}

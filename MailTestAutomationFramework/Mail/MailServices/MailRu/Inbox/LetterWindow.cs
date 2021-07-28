using OpenQA.Selenium;
using Mail.Base;
using Waiter;
using Mail.Util;

namespace Mail.MailServices.MailRu.Inbox
{
    /// <summary>
    /// Represents a class that describes an incoming message window.
    /// </summary>
    public class LetterWindow : BasePage
    {
        public IWebElement ShowHiddenPartButton =>
            Driver.FindElement(By.XPath("//div[@class='letter__body']//span[contains(@class, 'wrapper')][1]"), WaitTime);

        public IWebElement SenderAlias =>
            Driver.FindElement(By.XPath("//blockquote//br/parent::div"), WaitTime);

        private readonly int _separatingCharactersNumber = 4;

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public LetterWindow(IWebDriver driver) : base(driver)
        {
            base.WaitPageLoading();
        }

        /// <summary>
        /// Opens a hidden part of the message reply window.
        /// </summary>
        /// <returns>Letter window.</returns>
        public LetterWindow OpenHiddenPartReplyWindow()
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementToBeClickable(ShowHiddenPartButton);

            ShowHiddenPartButton.Click();

            return this;
        }

        /// <summary>
        /// Returns the alias from the received response.
        /// </summary>
        /// <returns>Alias.</returns>
        public string GetAliasFromReply()
        {
            new WaiterWrapper(Driver, WaitTime)
                .WaitElementIsVisible(SenderAlias);

            string alias = SenderAlias.Text;

            return alias.Remove(0, _separatingCharactersNumber);
        }

        /// <summary>
        /// Returns the alias from the last email response.
        /// </summary>
        /// <returns>Alias.</returns>
        public string GetAliasFromReplyLastLetter()
        {
            OpenHiddenPartReplyWindow();

            return GetAliasFromReply();
        }
    }
}

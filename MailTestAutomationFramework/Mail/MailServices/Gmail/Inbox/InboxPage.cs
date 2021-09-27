using Mail.Base;
using NLog;
using OpenQA.Selenium;

namespace Mail.MailServices.Gmail.Inbox
{
    /// <summary>
    /// Represents a class that describes an inbox page.
    /// </summary>
    public class InboxPage : BasePage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public InboxPage(IWebDriver driver) : base(driver)
        {
            WaitPageLoading();
        }

        /// <summary>
        /// Waiting for the home page to load.
        /// </summary>
        public override void WaitPageLoading()
        {
            base.WaitPageLoading();
        }

        /// <summary>
        /// Replies to the last received message.
        /// </summary>
        /// <param name="response">Response.</param>
        /// <returns>Inbox page.</returns>
        public InboxPage ReplyToLastLetter(Response response)
        {
            _logger.Info($"Reply to the last email with" +
                $" alias: {response.AliasName}, response text: {response.Text}.");

            return new InboxLettersWindow(Driver)
                    .OpenLastIncomingLetter()
                    .OpenReplyWindow()
                    .OpenHiddenPartReplyWindow()
                    .EnterReply(response.Text)
                    .ChangeAlias(response.AliasName)
                    .SendReply();
        }

        /// <summary>
        /// Checks if the last received message has been read.
        /// </summary>
        /// <returns>True, if the letter is not read, otherwise false.</returns>
        public bool IsNotReadedLastIncomingLetter()
        {
            return new InboxLettersWindow(Driver).IsNotReadedLastIncomingLetter();
        }

        /// <summary>
        /// Returns the email of the sender.
        /// </summary>
        /// <returns>Email.</returns>
        public string GetSenderEmail()
        {
            return new InboxLettersWindow(Driver).GetSenderEmail();
        }

        /// <summary>
        /// Returns the text of the letter.
        /// </summary>
        /// <returns>Text of the letter.</returns>
        public string GetLetterText()
        {
            return new InboxLettersWindow(Driver)
                .OpenLastIncomingLetter()
                .GetLetterText();
        }
    }
}

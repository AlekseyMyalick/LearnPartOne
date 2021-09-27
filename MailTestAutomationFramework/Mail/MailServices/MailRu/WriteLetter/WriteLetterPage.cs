using OpenQA.Selenium;
using NLog;
using Mail.Base;
using Mail.MailServices.MailRu.Home;

namespace Mail.MailServices.MailRu.WriteLetter
{
    /// <summary>
    /// This is the page describing the page for writing a letter.
    /// </summary>
    public class WriteLetterPage : BasePage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Web driver.</param>
        public WriteLetterPage(IWebDriver driver) : base(driver)
        {
            base.WaitPageLoading();
        }

        /// <summary>
        /// Sends a letter to the specified sender with the specified content.
        /// </summary>
        /// <param name="letter">Letter.</param>
        /// <returns>Home page.</returns>
        public HomePage WriteLetter(Letter letter)
        {
            HeadContainerWindow headContainerWindow = new HeadContainerWindow(Driver);
            headContainerWindow.TypeReceiver(letter.Receiver);

            EditorContainerWindow editorContainerWindow = new EditorContainerWindow(Driver);
            editorContainerWindow.TypeLetter(letter.Text).SubmitLetter();

            _logger.Info($"Write a letter to: {letter.Receiver}, text of the letter: {letter.Text}.");

            return headContainerWindow.CloseLayerWindow();
        }
    }
}

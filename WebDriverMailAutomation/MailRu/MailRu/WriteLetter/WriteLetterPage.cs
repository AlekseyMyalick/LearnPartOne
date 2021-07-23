using Mail.MailRu.Home;
using Mail.Base;
using NLog;
using OpenQA.Selenium;

namespace Mail.MailRu.WriteLetter
{
    /// <summary>
    /// This is the page describing the page for writing a letter.
    /// </summary>
    public class WriteLetterPage : BasePage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly string _writeLetterWindowXpath = "//div[contains(@class, 'compose-windows')]";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Web driver.</param>
        public WriteLetterPage(IWebDriver driver) : base(driver)
        {
            WaitPageLoading();
        }

        /// <summary>
        /// Waiting for the write letter page to load.
        /// </summary>
        public override void WaitPageLoading()
        {
            base.WaitPageLoading();

            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_writeLetterWindowXpath));
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

using OpenQA.Selenium;
using Waiters;


namespace GoogleMailModel.Pages
{
    public class InboxPage : BasePage
    {
        private readonly string _lastIncomingLetter = "//div[@class='Cp']/parent::div/child::div[last()]//tbody/child::tr[1]";
        private readonly string _lastLetterSender = "//span[@name]";
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

            string fontWeight = Driver.FindElement(By.XPath(_lastIncomingLetter + _lastLetterSender))
                .GetCssValue(_fontWeightCssPropertyName);

            return int.Parse(fontWeight) == _boldFontWeight;
        }

        /// <summary>
        /// Opens the last email that arrived.
        /// </summary>
        /// <returns>Incoming letter page.</returns>
        public IncomingLetterPage OpenLastIncomingLetter()
        {
            Waiter.WaitElementIsVisible(By.XPath(_lastIncomingLetter));

            Driver.FindElement(By.XPath(_lastIncomingLetter)).Click();

            return new IncomingLetterPage(Driver);
        }
    }
}

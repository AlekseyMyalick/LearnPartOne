using OpenQA.Selenium;
using NUnit.Framework;
using Mail.Driver;
using NUnit.Framework.Interfaces;
using Mail.Util;

namespace MailWebDriverTests
{
    public class CommonConditions
    {
        protected IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = DriverSingleton.GetDriver();
        }

        [TearDown]
        public void DriverQuit()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                new ScreenshotMaker().TakeScreenshot(_driver);
            }

            DriverSingleton.CloseDriver();
        }
    }
}
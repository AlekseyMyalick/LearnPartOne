using OpenQA.Selenium;
using NUnit.Framework;
using Mail.Driver;

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
            DriverSingleton.CloseDriver();
        }
    }
}

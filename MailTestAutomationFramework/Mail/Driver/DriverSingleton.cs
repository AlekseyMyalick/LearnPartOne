using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Mail.Driver
{
    /// <summary>
    /// Represents the controlling driver class.
    /// </summary>
    public class DriverSingleton
    {
        private static IWebDriver _driver;

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        private DriverSingleton() { }

        /// <summary>
        /// Returns an instance of the driver.
        /// </summary>
        /// <returns>A new driver if it has not been created
        /// before, otherwise the same driver instance.</returns>
        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                switch (TestContext.Parameters["browser"])
                {
                    default:
                        new DriverManager().SetUpDriver(new ChromeConfig(), "92.0.4515.107");
                        _driver = new ChromeDriver();
                        break;
                }

                _driver.Manage().Window.Maximize();
            }

            return _driver;
        }

        /// <summary>
        /// Closes the driver.
        /// </summary>
        public static void CloseDriver()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
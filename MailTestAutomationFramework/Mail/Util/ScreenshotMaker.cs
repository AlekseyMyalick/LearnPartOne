using System;
using NUnit.Framework;
using System.IO;
using OpenQA.Selenium;

namespace Mail.Util
{
    /// <summary>
    /// Represents a class whose methods take
    /// a screenshot of the visible portion of the screen.
    /// </summary>
    public class ScreenshotMaker
    {
        /// <summary>
        /// Takes and saves a screenshot of the visible part of the screen.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public void TakeScreenshot(IWebDriver driver)
        {
            ((ITakesScreenshot)driver)
                .GetScreenshot()
                .SaveAsFile(CreateFilename(), ScreenshotImageFormat.Png);
        }

        private string CreateTempDirectory()
        {
            string saveLocation = ".//screenshots/";

            if (!Directory.Exists(saveLocation))
            {
                Directory.CreateDirectory(saveLocation);
            }

            return saveLocation;
        }

        private string CreateFilename()
        {
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

            string testName = TestContext.CurrentContext.Test.FullName;

            return CreateTempDirectory() + testName + timeStamp + ".png";
        }
    }
}

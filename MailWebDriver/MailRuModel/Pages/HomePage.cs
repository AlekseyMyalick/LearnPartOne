﻿using OpenQA.Selenium;
using Waiters;

namespace MailRuModel.Pages
{
    /// <summary>
    /// It is a page describing the home page.
    /// </summary>
    public class HomePage : BasePage
    {
        private readonly string _writeLetterButton = "//span[text()='Написать письмо']";
        private readonly string _driverTitle = "Почта Mail.ru";

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public HomePage(IWebDriver driver) : base(driver)
        {
            WaitPageLoading();
        }

        /// <summary>
        /// Waiting for the home page to load.
        /// </summary>
        public override void WaitPageLoading()
        {
            Waiter.WaitTitleContains(_driverTitle);
        }

        /// <summary>
        /// Opens the page for writing a letter.
        /// </summary>
        /// <returns>Write letter page.</returns>
        public WriteLetterPage OpenWriteLetterPage()
        {
            Waiter.WaitElementIsVisible(By.XPath(_writeLetterButton));

            Driver.FindElement(By.XPath(_writeLetterButton)).Click();

            return new WriteLetterPage(Driver);
        }
    }
}

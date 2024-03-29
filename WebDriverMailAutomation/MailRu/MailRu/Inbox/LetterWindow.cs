﻿using Mail.Base;
using OpenQA.Selenium;

namespace Mail.MailRu.Inbox
{
    /// <summary>
    /// Represents a class that describes an incoming message window.
    /// </summary>
    public class LetterWindow : BasePage
    {
        public IWebElement ShowHiddenPartButton => Driver.FindElement(By.XPath("//div[@class='letter__body']//span[contains(@class, 'wrapper')][1]"));

        public IWebElement SenderAlias => Driver.FindElement(By.XPath("//blockquote//br/parent::div"));

        private readonly string _showHiddenPartButtonXpath = "//div[@class='letter__body']//span[contains(@class, 'wrapper')][1]";
        private readonly int _separatingCharactersNumber = 4;

        /// <summary>
        /// Initializes the fields of the class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public LetterWindow(IWebDriver driver) : base(driver)
        {
            WaitPageLoading();
        }

        /// <summary>
        /// Waiting for the login page to load.
        /// </summary>
        public override void WaitPageLoading()
        {
            base.WaitPageLoading();

            new Waiter.Waiter(Driver, WaitTime)
                .WaitElementIsVisible(By.XPath(_showHiddenPartButtonXpath));
        }

        /// <summary>
        /// Opens a hidden part of the message reply window.
        /// </summary>
        /// <returns>Letter window.</returns>
        public LetterWindow OpenHiddenPartReplyWindow()
        {
            ShowHiddenPartButton.Click();

            return this;
        }

        /// <summary>
        /// Returns the alias from the received response.
        /// </summary>
        /// <returns>Alias.</returns>
        public string GetAliasFromReply()
        {
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

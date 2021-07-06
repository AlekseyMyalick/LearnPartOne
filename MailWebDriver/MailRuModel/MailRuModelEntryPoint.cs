using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MailRuModel.Pages;
using System.Threading;

namespace MailRuModel
{
    class MailRuModelEntryPoint
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"D:\ChromDriver");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://account.mail.ru/login?page=https%3A%2F%2Fe.mail.ru%2Fmessages%2Finbox%3Futm_source%3Dportal%26utm_medium%3Dportal_navigation%26utm_campaign%3De.mail.ru&allow_external=1&from=octavius");

            try
            {
                LoginPage loginPage = new LoginPage(driver);
                
                HomePage homePage = loginPage.LoginAs("mail_ru.test@mail.ru", "158274Up");

                WriteLetterPage writeLetterPage = homePage.OpenWriteLetterPage();

                homePage = writeLetterPage.WriteLetter("g1mail2com3test@gmail.com", "Hello word");

                //Thread.Sleep(7000);

                driver.Quit();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                driver.Quit();
            }
            
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using GoogleMailModel.Pages;
using System.Threading;

namespace GoogleMailModel
{
    class GoogleMailModelEntryPoint
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"D:\ChromDriver");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://accounts.google.com/ServiceLogin/identifier?passive=1209600&continue=https%3A%2F%2Faccounts.google.com%2Fb%2F0%2FAddMailService&followup=https%3A%2F%2Faccounts.google.com%2Fb%2F0%2FAddMailService&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

            try
            {
                LoginPage loginPage = new LoginPage(driver);

                loginPage.LoginAs("g1mail2com3test@gmail.com", "Road1285");
                Thread.Sleep(7000);

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

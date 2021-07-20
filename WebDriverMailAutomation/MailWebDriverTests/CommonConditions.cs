using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Mail.Base;
using Mail.Driver;

namespace MailWebDriverTests
{
    public class CommonConditions
    {
        protected User UserMailRu => new User("robert.langdon.84@mail.ru", "158274Up");

        protected User UserGmail => new User("g1mail2com3test@gmail.com", "Road1285");

        protected User UserEmptyMailRu => new User(string.Empty, string.Empty);

        protected User UserNotExistMailRu => new User("svggcs@mail.ru", string.Empty);

        protected User UserEmptyPasswordMailRu => new User("robert.langdon.84@mail.ru", string.Empty);

        protected User UserInvalidPasswordMailRu => new User("robert.langdon.84@mail.ru", "wrong password");

        protected Letter SendLetter => new Letter(UserGmail.Email, "Hello World!");

        protected Response SendResponse => new Response("Hello my dear friend!", "Robdon");

        protected readonly string _oldNickname = "Robert Langdon";

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

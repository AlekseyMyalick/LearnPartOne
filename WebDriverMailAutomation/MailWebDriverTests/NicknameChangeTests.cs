using NUnit.Framework;
using Mail.Service;
using Mail.Util;
using MailRuPages = Mail.MailRu;
using GmailPages = Mail.Gmail;
using MailRu.Service;

namespace MailWebDriverTests
{
    [TestFixture]
    public class NicknameChangeTests : CommonConditions
    {
        [SetUp]
        public void SendLetterFromMailRu()
        {
            MailRuPages.WriteLetter.WriteLetterPage writeLetter
                = CreateDefaultMailRuPageUtils.CreateWriteLetterPage(_driver, UserCreator.UserMailRu);

            writeLetter.WriteLetter(LetterCreator.SendLetter);
        }

        [Test]
        [Category("All")]
        public void NicknameChange_CorrectChange_ReturnTrue()
        {
            GmailPages.Inbox.InboxPage inboxPage
                = CreateDefaultGmailPageUtils.CreateInboxPage(_driver, UserCreator.UserGmail);
            inboxPage.ReplyToLastLetter(ResponseCreator.SendResponse);

            MailRuPages.PersonalData.PersonalDataPage personalDataPageMailRu
                = CreateDefaultMailRuPageUtils.CreatePersonalDataPage(_driver, UserCreator.UserMailRu);

            personalDataPageMailRu.ChangeNickname(ResponseCreator.SendResponse.AliasName);
            MailRuPages.Home.HomePage homePageMailRu = personalDataPageMailRu.OpenHomePage();
            personalDataPageMailRu = homePageMailRu.OpenPersonalDataPage();

            string actualNickname = personalDataPageMailRu.GetNickname();

            Assert.AreEqual(ResponseCreator.SendResponse.AliasName.Name, actualNickname,
                $"The alias \"{actualNickname}\" does not " +
                $"match the expected \"{ResponseCreator.SendResponse.AliasName.Name}\".");
        }

        [TearDown]
        public void ReplaceWithOldAlias()
        {
            MailRuPages.PersonalData.PersonalDataPage personalDataPageMailRu
                = CreateDefaultMailRuPageUtils.CreatePersonalDataPage(_driver, UserCreator.UserMailRu);

            personalDataPageMailRu.ChangeNickname(AliasCreator.OldAlias);
        }
    }
}

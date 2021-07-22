using Mail.Base;
using MailRu.Service;

namespace Mail.Service
{
    public class UserCreator
    {
        public static readonly string TestDataUserNameMailRu = "testdata.mailru.user.name";
        public static readonly string TestDataUserPasswordMailRu = "testdata.mailru.user.password";
        public static readonly string TestDataUserNameGmail = "testdata.gmail.user.name";
        public static readonly string TestDataUserPasswordGmail = "testdata.gmail.user.password";

        public static User UserMailRu
            => new User(TestDataReader.GetTestData(TestDataUserNameMailRu),
                TestDataReader.GetTestData(TestDataUserPasswordMailRu));

        public static User UserGmail
            => new User(TestDataReader.GetTestData(TestDataUserNameGmail),
                TestDataReader.GetTestData(TestDataUserPasswordGmail));

        public static User UserEmptyMailRu
            => new User(string.Empty, string.Empty);

        public static User UserNotExistMailRu
            => new User("svggcs@mail.ru", string.Empty);

        public static User UserEmptyPasswordMailRu
            => new User(TestDataReader.GetTestData(TestDataUserNameMailRu), string.Empty);

        public static User UserInvalidPasswordMailRu
            => new User(TestDataReader.GetTestData(TestDataUserNameMailRu),
                TestDataReader.GetTestData(TestDataUserPasswordGmail));
    }
}

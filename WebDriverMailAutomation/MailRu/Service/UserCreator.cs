using Mail.Base;

namespace Mail.Service
{
    public class UserCreator
    {
        public static User UserMailRu => new User("robert.langdon.84@mail.ru", "158274Up");

        public static User UserGmail => new User("g1mail2com3test@gmail.com", "Road1285");

        public static User UserEmptyMailRu => new User(string.Empty, string.Empty);

        public static User UserNotExistMailRu => new User("svggcs@mail.ru", string.Empty);

        public static User UserEmptyPasswordMailRu => new User("robert.langdon.84@mail.ru", string.Empty);

        public static User UserInvalidPasswordMailRu => new User("robert.langdon.84@mail.ru", "wrong password");
    }
}

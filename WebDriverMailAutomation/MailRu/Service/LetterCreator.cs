using Mail.Base;

namespace Mail.Service
{
    public class LetterCreator
    {
        public static Letter SendLetter => new Letter(UserCreator.UserGmail.Email, "Hello World!");
    }
}

using Mail.Base;

namespace MailRu.Service
{
    public class AliasCreator
    {
        public static Alias OldAlias => new Alias("Robert Langdon");

        public static Alias NewAlias => new Alias("Robdon");
    }
}

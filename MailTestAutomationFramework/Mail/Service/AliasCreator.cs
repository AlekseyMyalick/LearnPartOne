using Mail.Base;

namespace Mail.Service
{
    public static class AliasCreator
    {
        public static Alias OldAlias => new Alias("Robert Langdon");

        public static Alias NewAlias => new Alias("Robdon");
    }
}

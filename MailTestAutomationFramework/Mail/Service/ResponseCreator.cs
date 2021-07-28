using Mail.Base;

namespace Mail.Service
{
    public static class ResponseCreator
    {
        public static Response SendResponse => new Response("Hello my dear friend!", AliasCreator.NewAlias);
    }
}

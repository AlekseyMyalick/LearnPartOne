using Mail.Base;
using MailRu.Service;

namespace Mail.Service
{
    public class ResponseCreator
    {
        public static Response SendResponse => new Response("Hello my dear friend!", AliasCreator.NewAlias);
    }
}

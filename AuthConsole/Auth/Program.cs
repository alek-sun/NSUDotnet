using System;
using System.Linq;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;

namespace Auth
{
    class Program
    {
        static void Main(string[] args)
        {
            VkApi api = new VkApi();
            api.Authorize(new VkNet.Model.ApiAuthParams()
            {
                Login = "ira10mir@yandex.ru",
                Password = "ежкинкорень",
                ApplicationId = 6972120,
                Settings = Settings.All
            });

            //var dialogs = api.Messages.GetConversations(new GetConversationsParams());
            //var messages = api.Messages.GetHistory(new MessagesGetHistoryParams()
            var res = api.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams
            {                             
                Fields = ProfileFields.All
            });
            //var friends = res.Select(x => x.FirstName);
            foreach (var f in res)
            {
                Console.WriteLine($"{f.FirstName} {f.LastName}");
            }           

            Console.WriteLine(res.TotalCount);

            Console.ReadLine();
        }
    }
}

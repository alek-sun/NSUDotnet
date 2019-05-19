using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace AuthoriseVK
{
    public class VKService : IDisposable
    {
        VkApi api;

        public VKService()
        {
            var services = new ServiceCollection();
            services.AddAudioBypass();
            api = new VkApi(services);
        }

        internal IEnumerable<User> GetFriends()
        {
            var res = api.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams
            {
                Fields = ProfileFields.All
            });
            return res;
        }

        internal void SendMessage(string text)
        {
            api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
            {
                RandomId = new Random().Next(),
                UserId = 61042798,
                Message = text
            });
        }

        public void Authorise(string login, string passw)
        {
            api.Authorize(new VkNet.Model.ApiAuthParams()
            {
                Login = login,
                Password = passw,
                ApplicationId = 6972120,
                Settings = Settings.All
            });                       
        }

        public void Dispose()
        {
            api.Dispose();
        }
    }
}

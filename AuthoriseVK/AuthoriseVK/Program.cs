using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;

namespace AuthoriseVK
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            VkApi api = new VkApi();
            api.Authorize(new VkNet.Model.ApiAuthParams()
            {
                Login = "ira10mir@yandex.ru",
                Password = "ежкинкорень",
                ApplicationId = 6972120,
                Settings = Settings.All
            });

            /*var dialogs = api.Messages.GetConversations(new GetConversationsParams());
            var messages = api.Messages.GetHistory(new MessagesGetHistoryParams()
            { PeerId = dialogs.Items[0].Conversation.Peer.Id });
            foreach (var msg in messages.Messages)
            {
                Console.WriteLine(msg.Text);
            }*/
            Console.WriteLine(api.Token);
            var res = api.Groups.Get(new GroupsGetParams());

            Console.WriteLine(res.TotalCount);

            Console.ReadLine();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new AuthorisationForm());
        }
    }
}

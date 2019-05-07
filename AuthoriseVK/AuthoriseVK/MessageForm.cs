using System;
using System.Windows.Forms;
using VkNet;
using VkNet.Enums.Filters;

namespace AuthoriseVK
{
    public partial class MessageForm : Form
    {
        VkApi api;
        public MessageForm()
        {
            InitializeComponent();
        }

        public MessageForm(VkApi vkApi)
        {
            InitializeComponent();
            api = vkApi;
            var res = api.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams
            {
                Fields = ProfileFields.All
            });

            foreach (var f in res)
            {
                FriendList.Items.Add($"{f.FirstName} {f.LastName}");
            }
        }     

        private void Button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(MessageText.Text);
            api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
            {
                RandomId = new Random().Next(),
                UserId = 61042798,
                Message = MessageText.Text
            });
        }
    }
}

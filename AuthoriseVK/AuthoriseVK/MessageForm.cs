using System;
using System.Windows.Forms;

namespace AuthoriseVK
{
    public partial class MessageForm : Form
    {
        VKService VKService;        

        public MessageForm(VKService VKService)
        {
            InitializeComponent();
            this.VKService = VKService;          
            
            foreach (var f in VKService.GetFriends())
            {
                FriendList.Items.Add($"{f.FirstName} {f.LastName}");
            }
        }     

        private void Button1_Click(object sender, EventArgs e)
        {
            VKService.SendMessage(MessageText.Text);            
        }
    }
}

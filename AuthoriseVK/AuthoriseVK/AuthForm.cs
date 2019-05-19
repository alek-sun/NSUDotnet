using System;
using System.Windows.Forms;

namespace AuthoriseVK
{
    public partial class AuthForm : Form
    {
        private VKService VKService;       

        public AuthForm()
        {
            InitializeComponent();
            VKService = new VKService();           
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                VKService.Authorise(loginBox.Text, passwBox.Text);
                var messageForm = new MessageForm(VKService);
                messageForm.Show();
            }
            catch (VkNet.Exception.VkApiAuthorizationException)
            {
                MessageBox.Show("Incorrect login or password, try again", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

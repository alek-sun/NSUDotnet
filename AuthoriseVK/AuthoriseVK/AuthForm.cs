using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Enums.Filters;

namespace AuthoriseVK
{
    public partial class AuthForm : Form
    {
        VkApi api;

        public AuthForm()
        {
            InitializeComponent();
            var services = new ServiceCollection();
            services.AddAudioBypass();
            api = new VkApi(services);            
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                api.Authorize(new VkNet.Model.ApiAuthParams()
                {
                    Login = loginBox.Text,
                    Password = passwBox.Text,
                    ApplicationId = 6972120,
                    Settings = Settings.All
                });
                var messageForm = new MessageForm(api);
                messageForm.Show();
            } catch (VkNet.Exception.VkApiAuthorizationException)
            {
                MessageBox.Show("Incorrect login or password, try again", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}

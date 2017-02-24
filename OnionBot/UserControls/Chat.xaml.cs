using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TwitchLib;
using TwitchLib.Common;
using TwitchLib.Models.Client;
using TwitchLib.Events.Client;
using TwitchLib.Events.Services;
using TwitchLib.Extensions.Client;
using System.Net.Sockets;

namespace OnionBot.UserControls
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : UserControl
    {
        TwitchClient client;
        ConnectionCredentials credentials;

        public Chat()
        {
            InitializeComponent();
            CheckConnected();
        }

        public void Refresh()
        {
            CheckConnected();
        }

        private void CheckConnected()
        {
            if (Libs.OAuth.OAuthToken == null)
            {
                chatBox.Items.Add("First connect your account with bot");
            }
            else
            {
                credentials = new ConnectionCredentials("tajfun695", Libs.OAuth.OAuthToken);
                client = new TwitchClient(credentials, "tajfun695");
                client.OnJoinedChannel += onJoinedChannel;
                client.OnMessageReceived += OnMessageReceived;

                client.Connect();
            }
        }

        private void OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            chatBox.Items.Add(e.ChatMessage.Username + ": " + e.ChatMessage.Message);
        }

        private void onJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            client.SendMessage("Hey guys! I am a bot connected via TwitchLib!");
        }


    }
}

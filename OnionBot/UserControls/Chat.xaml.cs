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
using System.Threading;

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
            credentials = new ConnectionCredentials("tajfuntest2", "oauth:1c4us8hjq24n385z27f85157m32r8j");
            client = new TwitchClient(credentials, "tajfun695");
            client.OnJoinedChannel += onJoinedChannel;
            //client.OnJoinedChannel += new EventHandler<OnMessageReceivedArgs>();
            client.OnMessageReceived += new EventHandler<OnMessageReceivedArgs>(globalChatMessageReceived);

            client.Connect();
            if (client.IsConnected) { chatBox.Items.Add($"Hello I`m {client.TwitchUsername}. I connected to your chat!"); }
            else { chatBox.Items.Add($"I have problem with connect to your chat!"); }
        }
        private void onJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            client.SendMessage($"Hey guys! I am a { e.Username} connected via TwitchLib!");
        }
        private void globalChatMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            ReceiveChatMessage(e.ChatMessage.Username, e.ChatMessage.Badges, e.ChatMessage.ColorHex, e.ChatMessage.Message);
        }

        private void viewerList(object sender, OnJoinedChannelArgs e)
        {
            //e.Username
        }
        private void ReceiveChatMessage(string username, List<KeyValuePair<string, string>> badges, string color, string message)
        {
                Models.ChatMessage _contentBase = new Models.ChatMessage();

                _contentBase.Username = username;
                _contentBase.Color = color;
                _contentBase.Badges = badges;
                _contentBase.Message = message;

                ViewModels.ChatMessage _contentView = new ViewModels.ChatMessage(_contentBase);
                chatBox.Items.Add(_contentView);
        }


    }
}

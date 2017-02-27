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
        #region Zmienne
        private string botName = "tajfuntest2";
        private string OAuth = "oauth:1c4us8hjq24n385z27f85157m32r8j";
        private string _channelName = "tajfun695";
        TwitchClient client;
        ConnectionCredentials credentials;
        #endregion

        public Chat()
        {
            InitializeComponent();
            credentials = new ConnectionCredentials(botName, OAuth);
            client = new TwitchClient(credentials, _channelName);
            client.OnJoinedChannel += onJoinedChannel;
            client.OnExistingUsersDetected += Client_OnJoinedChannel;
            client.OnMessageReceived += new EventHandler<OnMessageReceivedArgs>(globalChatMessageReceived);

            client.Connect();
            if (client.IsConnected) { chatBox.Items.Add($"Hello I`m {client.TwitchUsername}. I connected to your chat!"); }
            else { chatBox.Items.Add($"I have problem with connect to your chat!"); }
        }

        //kiedy dołacza bot do chatu :)
        private void onJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            client.SendMessage($"Hey guys! I am a { e.Username} connected via TwitchLib!");
        }
        //globalny chat
        private void globalChatMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                Models.ChatMessage _contentBase = new Models.ChatMessage();

                _contentBase.Username = e.ChatMessage.Username;
                _contentBase.Color = e.ChatMessage.ColorHex;
                _contentBase.Badges = e.ChatMessage.Badges;
                _contentBase.Message = e.ChatMessage.Message;

                ViewModels.ChatMessage _contentView = new ViewModels.ChatMessage(_contentBase);
                chatBox.Items.Add(_contentView);
            });
        }
        //viewer list
        private void Client_OnJoinedChannel(object sender, OnExistingUsersDetectedArgs e)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                foreach(var item in e.Users)
                {
                    viewerBox.Items.Add(item);
                }
            });
        }
        //wiadomosc do czatu
        private void msgBox_KeyDown(object sender, KeyEventArgs e)
        {
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("bot", "1"));
            if (e.Key == Key.Enter)
            {
                Models.ChatMessage _contentBot = new Models.ChatMessage();
                _contentBot.Username = botName;
                _contentBot.Color = Brushes.Purple.ToString();
                _contentBot.Message = msgBox.Text;
                _contentBot.Badges = list;
                ViewModels.ChatMessage _contentView = new ViewModels.ChatMessage(_contentBot);
                chatBox.Items.Add(_contentView);
                client.SendMessage(msgBox.Text);
                
            }
        }
    }
}

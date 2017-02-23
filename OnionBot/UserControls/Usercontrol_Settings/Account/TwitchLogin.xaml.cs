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
using System.Windows.Shapes;

namespace OnionBot.UserControls.Usercontrol_Settings.Account
{
    /// <summary>
    /// Interaction logic for TwitchLogin.xaml
    /// </summary>
    public partial class TwitchLogin : Window
    {
        public TwitchLogin()
        {
            InitializeComponent();
            webClient.Address = "https://api.twitch.tv/kraken/oauth2/authorize?response_type=token&amp;client_id=a4a9z3lf5b00it271smlkaxdajvf0un&amp;redirect_uri=http://localhost:8090&amp;scope=user_read+user_blocks_edit+user_blocks_read+user_follows_edit+channel_read+channel_editor+channel_commercial+channel_stream+channel_subscriptions+user_subscriptions+channel_check_subscription+chat_login";
        }

        private void btnCloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

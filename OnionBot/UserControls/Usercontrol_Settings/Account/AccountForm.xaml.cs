using System;
using System.Net;
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
using System.IO;

namespace OnionBot.UserControls.Usercontrol_Settings.Account
{
    /// <summary>
    /// Interaction logic for AccountForm.xaml
    /// </summary>
    public partial class AccountForm : UserControl
    {
        public AccountForm()
        {
            InitializeComponent();
        }

        private void btnTwitchConnect(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://api.twitch.tv/kraken/oauth2/authorize?response_type=token&amp;client_id=a4a9z3lf5b00it271smlkaxdajvf0un&amp;redirect_uri=http://localhost:8080&amp;scope=user_read+user_blocks_edit+user_blocks_read+user_follows_edit+channel_read+channel_editor+channel_commercial+channel_stream+channel_subscriptions+user_subscriptions+channel_check_subscription+chat_login");
            var web = new HttpListener();
            web.Prefixes.Add("http://localhost:8080/");
            web.Start();
            var context = web.GetContext();

            MessageBox.Show(context.Request.Url.OriginalString);

            var response = context.Response;

            const string responseString = "<html><body>Hello world</body></html>";

            var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;

            var output = response.OutputStream;

            output.Write(buffer, 0, buffer.Length);

            MessageBox.Show(output.ToString());

            output.Close();

            web.Stop();
        }
    }
}

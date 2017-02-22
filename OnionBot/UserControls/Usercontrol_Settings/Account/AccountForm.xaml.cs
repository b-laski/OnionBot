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
            System.Diagnostics.Process.Start(@"https://api.twitch.tv/kraken/oauth2/authorize?response_type=token&amp;client_id=a4a9z3lf5b00it271smlkaxdajvf0un&amp;redirect_uri=http://localhost:8090&amp;scope=user_read+user_blocks_edit+user_blocks_read+user_follows_edit+channel_read+channel_editor+channel_commercial+channel_stream+channel_subscriptions+user_subscriptions+channel_check_subscription+chat_login");
            var linkListener = new HttpListener();
            linkListener.Prefixes.Add("http://localhost:8090/");
            linkListener.Prefixes.Add("http://127.0.0.1:8090/");
            linkListener.Start();

            HttpListenerContext context = linkListener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            string responseMessage = "<html><head><title>Connecting with you Twitch account</title><script type=\"text / javascript\"> \nvar http = new XMLHttpRequest(); \nvar url = \" / auth - token\"; \nhttp.open(\"POST\", url, true); \nhttp.setRequestHeader(\"Content - Type\", \"application / json / \"); \nhttp.send(JSON.stringify({authToken: hash})); </script></head><body></body></html>";
            byte[] buffer = Encoding.UTF8.GetBytes(responseMessage);

            var cos = response.OutputStream.;
            MessageBox.Show(cos);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();

            linkListener.Stop();
        }
    }
}
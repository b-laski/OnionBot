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
        }

        private void btnCloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

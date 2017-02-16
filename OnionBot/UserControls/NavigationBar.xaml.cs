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

namespace OnionBot.UserControls
{
    /// <summary>
    /// Interaction logic for NavigationBar.xaml
    /// </summary>
    public partial class NavigationBar : UserControl
    {
        public delegate void MenuButtonClickEventHandler(object sender, EventArgs e);
        public event MenuButtonClickEventHandler MenuButtonClick;

        public NavigationBar()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            
            MenuButtonClick?.Invoke(this, new EventArgs());
        }
        

        public void menuPlace(Menu.SmallMenu.MenuList _click)
        {
            foreach(TextBlock item in gridControlNames.Children)
            {
                item.Visibility = Visibility.Collapsed;
            }

            if (_click == Menu.SmallMenu.MenuList.chat) { chatBlock.Visibility = Visibility.Visible; }
            else if (_click == Menu.SmallMenu.MenuList.dashboard) { dashboardBlock.Visibility = Visibility.Visible; }
            else if (_click == Menu.SmallMenu.MenuList.giveaway) { giveawayBlock.Visibility = Visibility.Visible; }
            else if (_click == Menu.SmallMenu.MenuList.songrequest) { songrequestBlock.Visibility = Visibility.Visible; }
            else if (_click == Menu.SmallMenu.MenuList.settings) { settingsBlock.Visibility = Visibility.Visible; }
        }
    }
}

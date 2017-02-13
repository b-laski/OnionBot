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
        public delegate void MenuButtonClickEventHandler(object sender, MenuButton e);
        public event MenuButtonClickEventHandler MenuButtonClick;

        public enum MenuButton
        {
            Open,
            Close
        }

        public NavigationBar()
        {
            InitializeComponent();
        }

        private void openMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuButtonClick?.Invoke(this, MenuButton.Open);
            btnOpenMenu.Visibility = Visibility.Collapsed;
            btnCloseMenu.Visibility = Visibility.Visible;
        }

        private void closeMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuButtonClick?.Invoke(this, MenuButton.Close);
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCloseMenu.Visibility = Visibility.Collapsed;
        }
    }
}
